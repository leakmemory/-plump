using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	[SerializeField]
	private Transform target; // игрок
	[SerializeField]
	private GameObject loseWidget;
	[SerializeField]
	private GameObject darkScreen;
	private GameData gameData;

	private float deltaDark = 2f;

	private SpriteRenderer darkScreenSprite;

	private bool saved = false; // чтобы сохранение постоянно не шло при проигрыше

	void Start() {
		darkScreenSprite = darkScreen.GetComponent<SpriteRenderer>();
		gameData = GameObject.Find("GameData").GetComponent<GameData>();
		gameData.PlayedGames();
		gameData.SaveData(); // сохраняем игру при старте
	}

	private bool lose = false; 
	private float time = 1f; // время падения камеры при проигрыше
	// Update is called once per frame
	void Update () {
		// рассеивание черного экрана перед стартом игры
		if (darkScreenSprite.color.a > 0 && !loseWidget.activeSelf) {
			Color color = darkScreenSprite.color;
			color.a -= deltaDark * Time.deltaTime;
			darkScreenSprite.color = color;
		}

		if (lose && time > 0) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, target.position.y, transform.position.z), Time.deltaTime * 70);
			time -= Time.deltaTime;
		} else {
			if (target.position.y > transform.position.y) {
				transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
			} else if (target.position.y < transform.position.y - 7f) {
				lose = true;
				if (!saved) {
					gameData.SaveData(); // сохраняем игру при проигрыше
					saved = true;
				}
			}
		}

		if (time <= 0) {
			loseWidget.SetActive(true);
		}
	}
}
