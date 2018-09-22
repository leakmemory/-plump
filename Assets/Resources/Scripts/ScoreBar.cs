using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	private Text score;
	private int maxScore = 0;
	public int Score { get { return maxScore; } }

	// Use this for initialization
	void Start () {
		score = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y * 10 > maxScore) {
			maxScore = (int)(player.transform.position.y * 10);
			score.text = maxScore.ToString();
		}
	}
}
