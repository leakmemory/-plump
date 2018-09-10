using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteController : MonoBehaviour {

	private List<GameObject> UIList;
	private float delta = 0; // дельта для исчезновения/появления

	// Use this for initialization
	void Start () {
		
	}

	public void AddList(List<GameObject> list) {
		UIList = list;
	}

	public void Disappear(float k = 1f) {
		delta = 2f;
		delta *= k; // коэффициент усиления для более быстрого/медленного исчезновения
	}

	public void Appear(float k = 1f) {
		delta = -2f;
		delta *= k; // коэффициент усиления для более быстрого/медленного исчезновения
	}

	// Update is called once per frame
	void Update () {
		if (delta != 0) {
			foreach (GameObject ui in UIList) {

				//сначала обрабатываем картинку
				Image image = ui.GetComponent<Image>();
				if (image) {
					Color color = image.color;
					color.a -= delta * Time.deltaTime;
					if (color.a < 0) {
						color.a = 0;
					}
					else if (color.a > 1f) {
						color.a = 1f;
					}
					image.color = color;
				} else continue;

				//затем текст
				Text text = image.GetComponentInChildren<Text>();
				if (text) {
					Color color = text.color;
					color.a -= delta * Time.deltaTime;
					if (color.a < 0) {
						color.a = 0;
					} else if (color.a > 1f) {
						color.a = 1f;
					}
					text.color = color;
				} else continue;
			}
		}
	}
}
