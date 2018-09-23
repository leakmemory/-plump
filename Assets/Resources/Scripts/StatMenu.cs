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
		totalPlayTime.text += TimeConvert(gameData.GetXmlValue("totalPlayTime"));
		longestPlayTime.text += TimeConvert(gameData.GetXmlValue("longestPlayTime"));
		maxScore.text += gameData.GetXmlValue("maxScore");
		maxJumps.text += gameData.GetXmlValue("maxJumps");
		maxCookies.text += gameData.GetXmlValue("maxCookies");
		lastPlayTime.text += TimeConvert(gameData.GetXmlValue("lastPlayTime"));
		lastScore.text += gameData.GetXmlValue("lastScore");
		lastJumps.text += gameData.GetXmlValue("lastJumps");
		lastCookies.text += gameData.GetXmlValue("lastCookies");
	}
	
	string TimeConvert(int time) {

		string resultTime = "";

		int days = 0;
		int hours = 0;
		int minutes = 0;
		int seconds = 0;

		days = time / 60 / 60 / 24;

		if (days > 0) {
			time -= days * 24 * 60 * 60;
			resultTime += days + "d ";
		}

		hours = time / 60 / 60;

		if (hours > 0) {
			time -= hours * 60 * 60;
			resultTime += hours + "h ";
		}

		minutes = time / 60;

		if (minutes > 0) {
			time -= minutes * 60;
			resultTime += minutes + "m ";
		}

		if (time > 0) {
			seconds = time;
			resultTime += time + "s";
		}

		return resultTime;
	}
}
