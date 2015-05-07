using UnityEngine;
using System.Collections;

public class ItemsSoundController : MonoBehaviour {

	public AudioClip sonidoMoneda;
	public float volumenMoneda = 1;
	public AudioClip sonidoGolpe;
	public float volumenGolpe = 1;
	public AudioClip sonidoReloj;
	public AudioClip sonidoFin;
	private AudioSource source;

	void Awake() {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Puntaje")) {
			source.PlayOneShot (sonidoMoneda, volumenMoneda);
		} else {
			source.PlayOneShot (sonidoGolpe, volumenGolpe);
		}
	}

	IEnumerator ClockTicking () {
		while (!GameController.gameOver) {
			if (GameController.gameTime < TimeController.timeWarning) {
				source.PlayOneShot (sonidoReloj, 100);
			}
			yield return new WaitForSeconds (1f);
		}
		yield return new WaitForSeconds (3f);
		source.PlayOneShot (sonidoFin, 5f);
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (ClockTicking ());
	}
	
	// Update is called once per frame
	void Update () {

	}
}
