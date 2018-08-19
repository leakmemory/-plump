using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	private float speed = 10f;
	private float movement = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal") * speed;
		if (Input.GetButton("Horizontal")) {
			if (movement < 0f)
				gameObject.transform.localScale = new Vector3(-1, 1, 1);
			else
				gameObject.transform.localScale = new Vector3(1, 1, 1);
		}
	}

	private void FixedUpdate() {
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}
}
