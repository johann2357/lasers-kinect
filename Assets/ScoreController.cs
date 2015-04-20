using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	private int score = 0;

	void Start() {
		scoreText.text = "SCORE: " + score.ToString ();
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Puntaje")) {
			score += 10;
			scoreText.text = "SCORE: " + score.ToString ();
		}
	}
}
