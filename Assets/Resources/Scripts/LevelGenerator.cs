using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject platformPrefab;
	private float width = 5f;
	private float minY = .5f, maxY = 1.5f;
	private int numberOfPlatforms = 200;

	// Use this for initialization
	void Start () {
		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++) {
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-width, width);
			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
