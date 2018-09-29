using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject playerObj;
	[SerializeField]
	private GameObject camera;
	[SerializeField]
	private GameObject loseWidget;
	[SerializeField]
	private GameObject darkScreen;
	[SerializeField]
	private ScoreBar scoreBar;
	[SerializeField]
	private LevelGenerator levelGenerator;
	private GameData gameData;

	List<XElement> groupsOfPlatforms = new List<XElement>(); // список групп из платформ
	private int createGroup = 1; // группа, которую нужно создать (изначально 1, т. к. две группы создадутся в начале уровня)
	private int scoreForGroup; // счет, при котором будет создана следующая группа в игре

	private float deltaDark = 2f;
	private bool lose = false;
	private bool saved = false; // чтобы игра постоянно не сохранялась при проигрыше

	private SpriteRenderer darkScreenSprite;
	private Camera gameCamera;
	private Player player;

	private float gameTime = 0f; // время в игре

	// Use this for initialization
	void Start () {
		XDocument level = XDocument.Parse(File.ReadAllText("Assets/Resources/XML/Level.xml"));
		XElement root = level.Element("root");
		foreach (XElement group in root.Elements("platformsGroup")) {
			groupsOfPlatforms.Add(group);
		}

		scoreForGroup = int.Parse(groupsOfPlatforms[0].Attribute("maxScore").Value);
		// создаем в начале игры две первые группы
		levelGenerator.GenerateGroup(groupsOfPlatforms[0], scoreForGroup);
		levelGenerator.GenerateGroup(groupsOfPlatforms[1], int.Parse(groupsOfPlatforms[1].Attribute("maxScore").Value));

		darkScreenSprite = darkScreen.GetComponent<SpriteRenderer>();
		gameData = GameObject.Find("GameData").GetComponent<GameData>();
		gameCamera = camera.GetComponent<Camera>();
		player = playerObj.GetComponent<Player>();
		gameData.SetValue("lastJumps", 0);
		gameData.SetValue("lastCookies", 0);
		gameData.SetValue("lastPlayTime", 0);
		gameData.IncrementValue("playedGames", 1);
		gameData.SaveData(); // сохраняем игру при старте
	}

	void CheckMax(string name, int value) {
		if (value > gameData.GetXmlValue(name)) {
			gameData.SetValue(name, value);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// рассеивание черного экрана перед стартом игры
		if (darkScreenSprite.color.a > 0 && !loseWidget.activeSelf) {
			Color color = darkScreenSprite.color;
			color.a -= deltaDark * Time.deltaTime;
			darkScreenSprite.color = color;
		}

		// если пора создать следующую группу
		if (scoreBar.Score > scoreForGroup) {
			int maxScore; // счет, до которого будет создаваться группа
			// проверяем, а не последняя ли это группа на уровне
			if (groupsOfPlatforms.Count - 1 == createGroup) {
				// если да, то вычисляем "высоту" группы
				int heightGroup = int.Parse(groupsOfPlatforms[createGroup].Attribute("maxScore").Value) -
					int.Parse(groupsOfPlatforms[createGroup - 1].Attribute("maxScore").Value);
				// т. к. последняя группа будет повторяться до бесконечности,
				// то счет для создания новой группы будет равен ее высоте,
				// а к счету, до которого она будет создаваться, нужно опять-таки прибавить высоту
				scoreForGroup += heightGroup;
				maxScore = scoreForGroup + heightGroup;
			} else {
				// счет для создания очередной группы берется от максимума текущей самой верхней группы
				scoreForGroup = int.Parse(groupsOfPlatforms[createGroup].Attribute("maxScore").Value);
				createGroup++;
				maxScore = int.Parse(groupsOfPlatforms[createGroup].Attribute("maxScore").Value);
			}
			levelGenerator.GenerateGroup(groupsOfPlatforms[createGroup], maxScore);
		}

		// если игрок упал
		if (playerObj.transform.position.y < camera.transform.position.y - 7f) {
			lose = true;
			gameCamera.Down = true;
			player.CanMove = false;
		}

		if (!lose) {
			gameTime += Time.deltaTime;
		}

		// когда камера перестала падать за игроком
		if (gameCamera.Standing) { 
			loseWidget.SetActive(true);
			if (!saved) {
				// очки
				gameData.SetValue("lastScore", scoreBar.Score);
				CheckMax("maxScore", scoreBar.Score);
				gameData.IncrementValue("totalScore", scoreBar.Score);

				// прыжки
				CheckMax("maxJumps", gameData.GetValue("lastJumps"));
				gameData.IncrementValue("totalJumps", gameData.GetValue("lastJumps"));

				// печеньки
				CheckMax("maxCookies", gameData.GetValue("lastCookies"));
				gameData.IncrementValue("totalCookies", gameData.GetValue("lastCookies"));

				// время
				gameData.SetValue("lastPlayTime", (int)gameTime);
				CheckMax("longestPlayTime", gameData.GetValue("lastPlayTime"));
				gameData.IncrementValue("totalPlayTime", gameData.GetValue("lastPlayTime"));

				gameData.SaveData();
				saved = true;
			}
		}
	}
}
