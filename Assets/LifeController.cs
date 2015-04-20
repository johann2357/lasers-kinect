﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour {

	public Text lifeText;
	private int life = 100;

	void Start() {
		lifeText.text = "LIFE: " + life.ToString ();
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Danino")) {
			life -= 1;
			lifeText.text = "LIFE: " + life.ToString ();
		}
		if (life <= 0) {
			GameController.gameOver = true;
		}
	}

}
