using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public Text positiveScoreText;
	public Text negativeScoreText;

	void Start() {
		updateScore ();
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Puntaje")) {
			// Show DeltaScoreText
			Text deltaScoreText = Instantiate (positiveScoreText) as Text;
			deltaScoreText.transform.SetParent(transform.parent.parent.Find("PointsCanvas"), false);
			deltaScoreText.text = "+50";
		
			// Destroy coin
			Destroy (collision.collider.gameObject);

			// Update score
			GameController.score += 50;

		} else if (collision.collider.gameObject.CompareTag ("Danino")) {
			Text deltaScoreText = Instantiate (negativeScoreText) as Text;
			deltaScoreText.transform.SetParent(transform.parent.parent.Find("PointsCanvas"), false);
			deltaScoreText.text = "-10";

			GameController.score -= 10;
		}
		updateScore ();

	}

	private void updateScore() {
		// Show score on top-right corcer
		scoreText.text = "SCORE: " + GameController.score.ToString ();
	}
}
