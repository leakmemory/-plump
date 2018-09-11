using System.Collections;
using System.Collections.Generic;
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
	private GameData gameData;

	private float deltaDark = 2f;
	private bool lose = false;
	private bool saved = false; // чтобы игра постоянно не сохранялась при проигрыше

	private SpriteRenderer darkScreenSprite;
	private Camera gameCamera;
	private Player player;

	// Use this for initialization
	void Start () {
		darkScreenSprite = darkScreen.GetComponent<SpriteRenderer>();
		gameData = GameObject.Find("GameData").GetComponent<GameData>();
		gameCamera = camera.GetComponent<Camera>();
		player = playerObj.GetComponent<Player>();
		gameData.PlayedGames();
		gameData.SaveData(); // сохраняем игру при старте
	}
	
	// Update is called once per frame
	void Update () {
		// рассеивание черного экрана перед стартом игры
		if (darkScreenSprite.color.a > 0 && !loseWidget.activeSelf) {
			Color color = darkScreenSprite.color;
			color.a -= deltaDark * Time.deltaTime;
			darkScreenSprite.color = color;
		}

		// если игрок упал
		if (playerObj.transform.position.y < camera.transform.position.y - 7f) {
			lose = true;
			gameCamera.Down = true;
			player.CanMove = false;
		}

		// когда камера перестала падать за игроком
		if (gameCamera.Standing) { 
			loseWidget.SetActive(true);
			if (!saved) {
				gameData.SaveData();
				saved = true;
			}
		}
	}
}
