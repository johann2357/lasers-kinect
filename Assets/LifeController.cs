using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour {

	private int life = 100;
	public Text DamageText;

	void Start() {
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Danino")) {
			Text damageText = Instantiate (DamageText) as Text;
			damageText.transform.SetParent(transform.parent.parent.Find("PointsCanvas"), false);
			GameController.score -= 10;
		}
		if (life <= 0) {
			GameController.gameOver = true;
		}
	}


}
