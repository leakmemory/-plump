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
	[SerializeField]
	private Text totalScore;
	[SerializeField]
	private Text totalPlayTime;
	[SerializeField]
	private Text longestPlayTime;
	[SerializeField]
	private Text maxScore;
	[SerializeField]
	private Text maxJumps;
	[SerializeField]
	private Text maxCookies;
	[SerializeField]
	private Text lastPlayTime;
	[SerializeField]
	private Text lastScore;
	[SerializeField]
	private Text lastJumps;
	[SerializeField]
	private Text lastCookies;

	// Use this for initialization
	void Start () {
		totalCookies.text += gameData.GetXmlValue("totalCookies");
		playedGame.text += gameData.GetXmlValue("playedGames");
		totalJumps.text += gameData.GetXmlValue("totalJumps");
		totalScore.text += gameData.GetXmlValue("totalScore");
		totalPlayTime.text += gameData.GetXmlValue("totalPlayTime");
		longestPlayTime.text += gameData.GetXmlValue("longestPlayTime");
		maxScore.text += gameData.GetXmlValue("maxScore");
		maxJumps.text += gameData.GetXmlValue("maxJumps");
		maxCookies.text += gameData.GetXmlValue("maxCookies");
		lastPlayTime.text += gameData.GetXmlValue("lastPlayTime");
		lastScore.text += gameData.GetXmlValue("lastScore");
		lastJumps.text += gameData.GetXmlValue("lastJumps");
		lastCookies.text += gameData.GetXmlValue("lastCookies");
	}
	
}
