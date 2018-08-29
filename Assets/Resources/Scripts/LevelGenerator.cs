using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject platformPrefab;
	[SerializeField]
	private GameObject movingPlatformPrefab;
	[SerializeField]
	private GameObject disappearingPlatform;
	[SerializeField]
	private GameObject cookiePrefab;
	[SerializeField]
	private Transform player;

	private float width = 5f; // ширина появления платформ
	private float minY = .5f, maxY = 1.5f; // расстояния до следующей платформы
	private int numberOfPlatforms = 200;
	private int numberOfCookie = 100;
	private List<Vector3> platformPosition = new List<Vector3>(); // храним позиции платформ в отдельном списке
	private List<GameObject> platforms = new List<GameObject>();

	// Use this for initialization
	void Start () {
		Vector3 spawnPosition = new Vector3();

		// генерируем позиции платформ в начале уровня
		for (int i = 0; i < numberOfPlatforms; i++) {
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-width, width);
			platformPosition.Add(spawnPosition);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// удаляем платформы, которые ниже камеры
		if (platforms.Count != 0) {
			foreach (GameObject platform in platforms) {
				if (platform.transform.position.y < player.position.y - 5f) {
					platforms.Remove(platform);
					Destroy(platform);
					break;
				}
			}
		}
		// добавляем платформы, положения которых приближаются к игроку
		if (platformPosition.Count != 0) {
			foreach (Vector3 position in platformPosition) {
				if (position.y < player.transform.position.y + 5f) {
					GameObject platform = platformPrefab;
					// иногда появляются двигающиеся платформы
					if (Random.Range(0, 9) == 5) {
						platform = movingPlatformPrefab;
					}
					// и исчезающие
					else if (Random.Range(0, 9) == 1) {
						platform = disappearingPlatform;
					}
					if (Random.Range(0, 9) == 2 && platform != movingPlatformPrefab && numberOfCookie != 0) {
						Vector3 cookiePosition = position;
						GameObject cookie = Instantiate(cookiePrefab, position, Quaternion.identity);

						cookiePosition.y += platform.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 +
							cookie.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2;
						cookie.transform.position = cookiePosition;
						numberOfCookie--;
					}
					platforms.Add(Instantiate(platform, position, Quaternion.identity));
					platformPosition.Remove(position);
					break;
				}
			}
		}
	}
}
