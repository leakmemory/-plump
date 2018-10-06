using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour {

	[SerializeField]
	private GameObject player;
	[SerializeField]
	private Text score;
	[SerializeField]
	private Text numberOfCookies;
	private GameData gameData;

	private int maxScore = 0;
	private int cookies;
	public int Score { get { return maxScore; } }

	// Use this for initialization
	void Start () {
		gameData = GameObject.Find("GameData").GetComponent<GameData>();
		cookies = gameData.GetValue("currentCookies");
		numberOfCookies.text = cookies.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y * 10 > maxScore) {
			maxScore = (int)(player.transform.position.y * 10);
			score.text = maxScore.ToString();
		}
		if (gameData.GetValue("currentCookies") > cookies) {
			cookies = gameData.GetValue("currentCookies");
			numberOfCookies.text = cookies.ToString();
		}
	}
}
