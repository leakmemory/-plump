using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private float jumpForce = 10f;
	public float JumpForce { set { jumpForce = value; } }

	private GameData gameData;

	virtual public void OnCollisionEnter2D(Collision2D collision) {

		if (collision.relativeVelocity.y <= 0) {

			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb) {
				gameData = GameObject.Find("GameData").GetComponent<GameData>(); // TODO: Надо бы понять, почему gameData не находится из Start
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
				gameData.IncrementValue("totalJumps", 1);
			}
		}
	}

	public void SetColor(Color color) {
		GetComponent<SpriteRenderer>().color = color;
	}
}
