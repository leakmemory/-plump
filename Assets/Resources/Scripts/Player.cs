using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	private float speed = 500f;
	private float movement = 0f; // расстояние, на которое перемещается игрок
	private bool canMove = true;
	public bool CanMove { set { canMove = value; } }
	private float startJumpForce = 15f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		// начальный прыжок игрока
		Vector2 velocity = rb.velocity;
		velocity.y = startJumpForce;
		rb.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove) return;

		movement = Input.GetAxis("Horizontal") * speed;
		// отзеркаливание игрока
		if (Input.GetButton("Horizontal")) {
			if (movement < 0f)
				gameObject.transform.localScale = new Vector3(-1, 1, 1);
			else
				gameObject.transform.localScale = new Vector3(1, 1, 1);
		}
	}

	private void FixedUpdate() {
		if (!canMove) return;

		Vector2 velocity = rb.velocity;
		velocity.x = movement * Time.fixedDeltaTime;
		rb.velocity = velocity;
	}
}
