using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : Platform {

	private SpriteRenderer sr;
	private EdgeCollider2D ec;
	private float delta = 0f;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		ec = GetComponent<EdgeCollider2D>();
	}

	public override void OnCollisionEnter2D(Collision2D collision) {
		base.OnCollisionEnter2D(collision);
		if (collision.relativeVelocity.y <= 0) {
			delta = .2f;
			ec.enabled = false;
		}
	}

	void Update() {
		if (delta > 0) {
			Color clr = sr.color;
			clr.a -= delta;
			sr.color = clr;
		}
	}
}
