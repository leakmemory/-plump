using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMenu : MonoBehaviour {

	[SerializeField]
	private GameData gameData;
	[SerializeField]
	private Text totalCookies;
	[SerializeField]
	private Text playedGame;
	[SerializeField]
	private Text totalJumps;

	// Use this for initialization
	void Start () {
		totalCookies.text += gameData.GetValue("totalCookies");
		playedGame.text += gameData.GetValue("playedGames");
		totalJumps.text += gameData.GetValue("totalJumps");
	}
	
}
