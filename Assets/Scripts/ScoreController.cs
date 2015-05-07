using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public Text positiveScoreText;
	public Text negativeScoreText;
	public Text finalScoreText;

	void Start() {
		updateScore ();
		StartCoroutine (CheckIfEnd ());
	}

	IEnumerator CheckIfEnd ()
	{
		while (!GameController.gameOver) {
			yield return new WaitForSeconds (1f);
		}
		yield return new WaitForSeconds (3f);
		scoreText.text = "";
		finalScoreText.text = "YOU GOT"; 
		yield return new WaitForSeconds (3f);
		if (GameController.score <= 0) {
			finalScoreText.color = Color.red;
		} else {
			finalScoreText.color = Color.green;
		}
		finalScoreText.text = GameController.score.ToString ();
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
		if (GameController.score < 0) {
			scoreText.color = Color.red;
		} else {
			scoreText.color = Color.yellow;
		}
		scoreText.text = "SCORE: " + GameController.score.ToString ();
	}

}
