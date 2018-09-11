using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	[SerializeField]
	private Transform target; // игрок
	private bool down = false; // камера падает вниз
	private bool standing = false; // камера статична
	public bool Down { set { down = value; } }
	public bool Standing { get { return standing; } }
	private float downTime = 1f;

	void Start() {

	}

	// Update is called once per frame
	void Update () {
		// камера падает
		if (down) {
			if (downTime > 0) {
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, target.position.y, transform.position.z), Time.deltaTime * 70);
				downTime -= Time.deltaTime;
			}
			else {
				standing = true;
			}
		} 
		// камера движется за игроком
		else if (target.position.y > transform.position.y) {
			transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
		} 
	}
}
