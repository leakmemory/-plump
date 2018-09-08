using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform {

	private float deltaMove = 2f;
	private float startPosition;
	private float speed;
	private bool rightDirection = true;

	// Use this for initialization
	void Start () {
		startPosition = transform.position.x;
		speed = Random.Range(1f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= startPosition + deltaMove) rightDirection = false;
		else if (transform.position.x <= startPosition - deltaMove)	rightDirection = true;

		if (rightDirection) {
			transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, Time.deltaTime * speed);
		} else {
			transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.right, Time.deltaTime * speed);
		}
	}
}
