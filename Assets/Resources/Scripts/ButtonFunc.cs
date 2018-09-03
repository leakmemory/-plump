using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour {

	public void StartNewGame() {
		SceneManager.LoadScene("Game");
	}

}
