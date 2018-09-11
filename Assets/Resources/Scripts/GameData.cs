using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class GameData : MonoBehaviour {

	private string savePath;
	private XElement root;

	private int totalCookies;
	private int playedGames;
	private int totalJumps;

	private SortedDictionary<string, int> data = new SortedDictionary<string, int>();

	// Use this for initialization
	void Start() {
		savePath = Application.persistentDataPath + "/GameData.xml";

		totalCookies = 0;
		playedGames = 0;
		totalJumps = 0;

		data.Add("totalCookies", totalCookies);
		data.Add("playedGames", playedGames);
		data.Add("totalJumps", totalJumps);
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
				data[val.Key] = int.Parse(root.Element(val.Key).Value);
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

	public string GetValue(string name) {
		return root.Element(name).Value;
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
