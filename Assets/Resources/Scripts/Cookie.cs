using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour {

	private Transform camera;
	private GameData gameData;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find("Main Camera").transform;
		gameData = GameObject.Find("GameData").GetComponent<GameData>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		gameData.IncrementValue("totalCookies", 1);
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < camera.position.y - 5f) {
			Destroy(gameObject);
		}
	}
}
