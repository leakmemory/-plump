using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private GameObject darkScreen;
	[SerializeField]
	private GameObject playBtn;
	[SerializeField]
	private GameObject statBtn;
	[SerializeField]
	private GameObject optionsBtn;

	private SpriteRenderer darkScreenSprite;
	private Image playImg; // картинка
	private Text playTxt; // и текст кнопки
	private Image optionsImg;
	private Text optionsTxt;
	private Image statImg;
	private Text statTxt;
	private float deltaDisappear = 0f;
	private float deltaDark = 2f;

	// Use this for initialization
	void Start () {
		darkScreenSprite = darkScreen.GetComponent<SpriteRenderer>();
		playImg = playBtn.GetComponent<Image>();
		playTxt = playImg.GetComponentInChildren<Text>();
		optionsImg = optionsBtn.GetComponent<Image>();
		optionsTxt = optionsImg.GetComponentInChildren<Text>();
		statImg = statBtn.GetComponent<Image>();
		statTxt = statImg.GetComponentInChildren<Text>();
	}

	public void StartGame() {
		deltaDisappear = 2f;
	}

	// Update is called once per frame
	void Update () {
		// рассеивание черного экрана перед стартом игры
		if (darkScreenSprite.color.a > 0 && deltaDisappear == 0) {
			Color color = darkScreenSprite.color;
			color.a -= deltaDark * Time.deltaTime;
			darkScreenSprite.color = color;

			// исчезновение кнопки
			color = playImg.color;
			color.a += 2 * deltaDark * Time.deltaTime;
			playImg.color = color;
			optionsImg.color = color;
			statImg.color = color;

			// исчезновение текста кнопки
			color = playTxt.color;
			color.a += 2 * deltaDark * Time.deltaTime;
			playTxt.color = color;
			optionsTxt.color = color;
			statTxt.color = color;
		}

		if (deltaDisappear > 0) {
			if (darkScreenSprite.color.a >= 1f) {
				SceneManager.LoadScene("Game");
			}

			// появление черного экрана
			Color color = darkScreenSprite.color;
			color.a += deltaDisappear * Time.deltaTime;
			darkScreenSprite.color = color;

			// исчезновение кнопки
			color = playImg.color;
			color.a -= 3 * deltaDisappear * Time.deltaTime;
			playImg.color = color;
			optionsImg.color = color;
			statImg.color = color;

			// исчезновение текста кнопки
			color = playTxt.color;
			color.a -= 3 * deltaDisappear * Time.deltaTime;
			playTxt.color = color;
			optionsTxt.color = color;
			statTxt.color = color;
		}
	}
}
