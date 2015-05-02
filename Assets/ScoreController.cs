using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public Text DeltaScoreText;

	void Start() {
		scoreText.text = "SCORE: " + GameController.score.ToString ();
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Puntaje")) {
			// Show DeltaScoreText
			Text deltaScoreText = Instantiate (DeltaScoreText) as Text;
			deltaScoreText.transform.SetParent(transform.parent.parent.Find("PointsCanvas"), false);
		
			// Destroy coin
			Destroy (collision.collider.gameObject);

			// Update score
			GameController.score += 50;

		}
		updateScore ();

	}

	private void updateScore() {
		// Show score on top-right corcer
		scoreText.text = "SCORE: " + GameController.score.ToString ();
	}
}
