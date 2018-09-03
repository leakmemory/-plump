using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	[SerializeField]
	private Transform target; // игрок
	[SerializeField]
	private GameObject loseWidget;

	private bool lose = false; 
	private float time = 1f; // время падения камеры при проигрыше
	// Update is called once per frame
	void Update () {
		if (lose && time > 0) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, target.position.y, transform.position.z), Time.deltaTime * 70);
			time -= Time.deltaTime;
		} else {
			if (target.position.y > transform.position.y) {
				transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
			} else if (target.position.y < transform.position.y - 7f) {
				lose = true;
			}
		}

		if (time <= 0) {
			loseWidget.SetActive(true);
		}
	}
}
