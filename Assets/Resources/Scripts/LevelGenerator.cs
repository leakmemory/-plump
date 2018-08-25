using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject platformPrefab;
	[SerializeField]
	private GameObject movingPlatformPrefab;
	[SerializeField]
	private Transform player;

	private float width = 5f;
	private float minY = .5f, maxY = 1.5f;
	private int numberOfPlatforms = 200;
	private List<Vector3> platformPosition = new List<Vector3>();
	private List<GameObject> platforms = new List<GameObject>();

	// Use this for initialization
	void Start () {
		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++) {
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-width, width);
			platformPosition.Add(spawnPosition);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (platforms.Count != 0) {
			foreach (GameObject platform in platforms) {
				if (platform.transform.position.y < player.position.y - 5f) {
					platforms.Remove(platform);
					Destroy(platform);
					break;
				}
			}
		}

		if (platformPosition.Count != 0) {
			foreach (Vector3 position in platformPosition) {
				if (position.y < player.transform.position.y + 5f) {
					GameObject platform = platformPrefab;
					if (Random.Range(0, 9) == 5) {
						platform = movingPlatformPrefab;
					}
					platforms.Add(Instantiate(platform, position, Quaternion.identity));
					platformPosition.Remove(position);
					break;
				}
			}
		}
	}
}
