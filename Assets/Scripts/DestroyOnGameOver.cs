using UnityEngine;
using System.Collections;

public class DestroyOnGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.gameOver == true) {
			Destroy(gameObject);
		}
	}
}
