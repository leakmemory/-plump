using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour {

	[SerializeField]
	private GameObject darkScreen;
	[SerializeField]
	private GameObject playAgainBtn;
	[SerializeField]
	private GameObject backBtn;
	[SerializeField]
	private GameObject scoreBar;
	[SerializeField]
	private GameObject cookie;
	[SerializeField]
	private UISpriteController UISpriteController;
	private List<GameObject> editingUI = new List<GameObject>();
	private GameData gameData;

	private SpriteRenderer darkScreenSprite;
	private float deltaDisappear = 0f;
	private bool startNewGame = false; // флаги, что нажата одна
	private bool backToMenu = false; // из двух кнопок

	void Start() {
		gameData = GameObject.Find("GameData").GetComponent<GameData>();
		darkScreenSprite = darkScreen.GetComponent<SpriteRenderer>();

		//объекты, которые должны исчезнуть/появиться
		editingUI.Add(playAgainBtn);
		editingUI.Add(backBtn);
		editingUI.Add(scoreBar);
		editingUI.Add(cookie);

		UISpriteController.AddList(editingUI);
	}

	public void StartNewGame() {
		deltaDisappear = 2f;
		startNewGame = true;
		UISpriteController.Disappear(2f);
	}

	public void BackToMenu() {
		deltaDisappear = 2f;
		backToMenu = true;
		UISpriteController.Disappear(2f);
		Destroy(gameData.gameObject); // удаляем, т. к. в стартовом меню есть своя GameData
	}

	void Update() {
		if (startNewGame || backToMenu) {
			if (darkScreenSprite.color.a >= 1f) {
				if (startNewGame) {
					SceneManager.LoadScene("Game");
				}
				else if (backToMenu) {
					SceneManager.LoadScene("StartMenu");
				}
			}

			// появление черного экрана
			Color color = darkScreenSprite.color;
			color.a += deltaDisappear * Time.deltaTime;
			darkScreenSprite.color = color;
		}
	}
}
