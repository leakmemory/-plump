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
	[SerializeField]
	private UISpriteController UISpriteController;

	private SpriteRenderer darkScreenSprite;
	private List<GameObject> editingUI = new List<GameObject>();

	private float deltaDisappear = 0f;
	private float deltaDark = 2f;

	// Use this for initialization
	void Start () {
		darkScreenSprite = darkScreen.GetComponent<SpriteRenderer>();

		//объекты, которые должны исчезнуть/появиться
		editingUI.Add(playBtn);
		editingUI.Add(statBtn);
		editingUI.Add(optionsBtn);

		UISpriteController.AddList(editingUI);
		UISpriteController.Appear(); //в стартовом меню сразу появляются объекты
	}

	public void StartGame() {
		deltaDisappear = 2f;
		UISpriteController.Disappear(2f);
	}

	// Update is called once per frame
	void Update () {
		// рассеивание черного экрана перед стартом игры
		if (darkScreenSprite.color.a > 0 && deltaDisappear == 0) {
			Color color = darkScreenSprite.color;
			color.a -= deltaDark * Time.deltaTime;
			darkScreenSprite.color = color;
		}

		if (deltaDisappear > 0) {
			if (darkScreenSprite.color.a >= 1f) {
				SceneManager.LoadScene("Game");
			}

			// появление черного экрана
			Color color = darkScreenSprite.color;
			color.a += deltaDisappear * Time.deltaTime;
			darkScreenSprite.color = color;
		}
	}
}
