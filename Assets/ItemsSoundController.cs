using UnityEngine;
using System.Collections;

public class ItemsSoundController : MonoBehaviour {

	public AudioClip sonidoMoneda;
	public AudioClip sonidoGolpe;
	private AudioSource source;

	void Awake() {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Puntaje")) {
			source.PlayOneShot (sonidoMoneda, 1);
		} else {
			source.PlayOneShot (sonidoGolpe, 1);
		}
			
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
