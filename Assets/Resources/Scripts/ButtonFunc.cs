using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunc : MonoBehaviour {

	[SerializeField]
	private GameObject darkScreen;
	[SerializeField]
	private GameObject playAgainBtn;

	private SpriteRenderer darkScreenSprite;
	private Image playAgainImg; // картинка
	private Text playAgainTxt; // и текст кнопки
	private float deltaDisappear = 0f;

	void Start() {
		darkScreenSprite = darkScreen.GetComponent<SpriteRenderer>();
		playAgainImg = playAgainBtn.GetComponent<Image>();
		playAgainTxt = playAgainImg.GetComponentInChildren<Text>();
	}

	public void StartNewGame() {
		deltaDisappear = 2f;
	}

	void Update() {
		if (deltaDisappear > 0) {
			if (darkScreenSprite.color.a >= 1f) {
				SceneManager.LoadScene("Game");
			}
			
			// появление черного экрана
			Color color = darkScreenSprite.color;
			color.a += deltaDisappear * Time.deltaTime;
			darkScreenSprite.color = color;

			// исчезновение кнопки
			color = playAgainImg.color;
			color.a -= 2 * deltaDisappear * Time.deltaTime;
			playAgainImg.color = color;
			playAgainTxt.color = color;

		}
	}

}
