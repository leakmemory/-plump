using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class GameData : MonoBehaviour {

	private string savePath;
	private XElement root;

	private int playedGames; // количество сыгранных игр

	private int totalCookies; // печеньки за все игры
	private int totalJumps; // количество прыжков за все игры
	private int totalScore; // количество очков за все игры
	private int totalPlayTime; // количество сыгранного времени

	private int longestPlayTime; // самая длинная сессия в игре
	private int maxScore; // максимум
	private int maxJumps; // за одну
	private int maxCookies; // игру

	private int lastScore; // результаты
	private int lastJumps; // за
	private int lastCookies; // последнюю
	private int lastPlayTime; // игру

	private int currentCookies; // текущее количество печенек

	private SortedDictionary<string, int> data = new SortedDictionary<string, int>();

	// Use this for initialization
	void Start() {
		savePath = Application.persistentDataPath + "/GameData.xml";

		totalCookies = 0;
		playedGames = 0;
		totalJumps = 0;
		totalScore = 0;
		totalPlayTime = 0;
		longestPlayTime = 0;
		maxScore = 0;
		maxJumps = 0;
		maxCookies = 0;
		lastScore = 0;
		lastJumps = 0;
		lastCookies = 0;
		lastPlayTime = 0;
		currentCookies = 0;

		data.Add("totalCookies", totalCookies);
		data.Add("playedGames", playedGames);
		data.Add("totalJumps", totalJumps);
		data.Add("totalScore", totalScore);
		data.Add("totalPlayTime", totalPlayTime);
		data.Add("longestPlayTime", longestPlayTime);
		data.Add("maxScore", maxScore);
		data.Add("maxJumps", maxJumps);
		data.Add("maxCookies", maxCookies);
		data.Add("lastScore", lastScore);
		data.Add("lastJumps", lastJumps);
		data.Add("lastCookies", lastCookies);
		data.Add("lastPlayTime", lastPlayTime);
		data.Add("currentCookies", currentCookies);

		LoadData();

		DontDestroyOnLoad(gameObject);
	}

	private void LoadData() {
		if (!File.Exists(savePath)) {
			Debug.Log("Couldn't find GameData.xml. Create new!");
			SaveData();
		} else {
			XDocument gameData = XDocument.Parse(File.ReadAllText(savePath));
			root = gameData.Element("root");

			foreach (KeyValuePair<string, int> val in data) {
				data[val.Key] = GetXmlValue(val.Key);
			}

			Debug.Log("GameData.xml loaded!");
		}
	}

	public void SaveData() {
		root = new XElement("root");

		foreach (KeyValuePair<string, int> val in data) {
			root.Add(new XElement(val.Key, val.Value));
		}

		XDocument gameData = new XDocument(root);
		File.WriteAllText(savePath, gameData.ToString());
		Debug.Log("Save game!");
	}

	public int GetXmlValue(string name) {
		return int.Parse(root.Element(name).Value);
	}

	public int GetValue(string name) {
		return data[name];
	}

	public void IncrementValue(string name, int value) {
		data[name] += value;
	}

	public void SetValue(string name, int value) {
		data[name] = value;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
