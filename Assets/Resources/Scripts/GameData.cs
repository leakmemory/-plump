using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class GameData : MonoBehaviour {

	private int totalCookies;
	private int playedGame;
	private int totalJumps;
	private string savePath;
	private XDocument gameData;

	// Use this for initialization
	void Start () {
		savePath = Application.persistentDataPath + "/GameData.xml";

		totalCookies = 0;
		playedGame = 0;
		totalJumps = 0;
		LoadData();

		DontDestroyOnLoad(gameObject);
	}

	private void LoadData() {
		if (!File.Exists(savePath)) {
			Debug.Log("Couldn't find GameData.xml. Create new!");
			gameData = new XDocument();
			File.WriteAllText(savePath, gameData.ToString());
		}
		else {
			gameData = XDocument.Parse(File.ReadAllText(savePath));
			XElement root = gameData.Element("root");

			totalCookies = int.Parse(root.Element("totalCookies").Value);
			playedGame = int.Parse(root.Element("playedGame").Value);
			totalJumps = int.Parse(root.Element("totalJumps").Value);
			Debug.Log("GameData.xml loaded!");
		}
	}

	public void SaveData() {
		XElement root = new XElement("root");
		root.Add(new XElement("totalCookies", totalCookies));
		root.Add(new XElement("playedGame", playedGame));
		root.Add(new XElement("totalJumps", totalJumps));

		gameData = new XDocument(root);
		File.WriteAllText(savePath, gameData.ToString());
		Debug.Log("Save game!");
	}

	public void PlayedGames() {
		playedGame++;
	}

	public void TotalCookies() {
		totalCookies++;
	}

	public void TotalJumps() {
		totalJumps++;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
