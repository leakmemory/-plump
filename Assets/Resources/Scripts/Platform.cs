﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private float jumpForce = 10f;
	public float JumpForce { set { jumpForce = value; } }

	virtual public void OnCollisionEnter2D(Collision2D collision) {

		if (collision.relativeVelocity.y <= 0) {

			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb) {
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
			}
		}
	}

	public void SetColor(Color color) {
		GetComponent<SpriteRenderer>().color = color;
	}
}
