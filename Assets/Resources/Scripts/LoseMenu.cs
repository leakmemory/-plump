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

	private SpriteRenderer darkScreenSprite;
	private Image playAgainImg; // картинка
	private Text playAgainTxt; // и текст кнопки
	private Image backImg;
	private Text backTxt;
	private float deltaDisappear = 0f;
	private bool startNewGame = false; // флаги, что нажата одна
	private bool backToMenu = false; // из двух кнопок

	void Start() {
		darkScreenSprite = darkScreen.GetComponent<SpriteRenderer>();
		playAgainImg = playAgainBtn.GetComponent<Image>();
		playAgainTxt = playAgainImg.GetComponentInChildren<Text>();
		backImg = backBtn.GetComponent<Image>();
		backTxt = backImg.GetComponentInChildren<Text>();
	}

	public void StartNewGame() {
		deltaDisappear = 2f;
		startNewGame = true;
	}

	public void BackToMenu() {
		deltaDisappear = 2f;
		backToMenu = true;
	}

	void Update() {
		if (deltaDisappear > 0) {
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

			// исчезновение кнопки
			color = playAgainImg.color;
			color.a -= 2 * deltaDisappear * Time.deltaTime;
			playAgainImg.color = color;
			backImg.color = color;

			// исчезновение текста кнопки
			color = playAgainTxt.color;
			color.a -= 2 * deltaDisappear * Time.deltaTime;
			playAgainTxt.color = color;
			backTxt.color = color;

		}
	}
}
