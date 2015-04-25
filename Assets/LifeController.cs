using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour {

	public GameObject damageText;
	public Text lifeText;
	private int life = 100;

	void Start() {
		lifeText.text = "LIFE: " + life.ToString ();
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Danino")) {
			SpawnDamage (1, transform.position.x, transform.position.y);
			life -= 1;
			lifeText.text = "LIFE: " + life.ToString ();
		}
		if (life <= 0) {
			GameController.gameOver = true;
		}
	}

	void SpawnDamage (float damage, float x, float y) {
		x = Mathf.Clamp (x, 0.05f, 0.95f);
		y = Mathf.Clamp (y, 0.05f, 0.9f);
		GameObject gui = Instantiate (damageText, new Vector3 (x, y, 0.0f), Quaternion.identity) as GameObject;
		gui.GetComponent<Text> ().text = damage.ToString ();
	}

}
