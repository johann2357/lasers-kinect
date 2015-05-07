using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {
	public Text timeText;
	public static float timeWarning = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateTime ();
	}

	private void updateTime() {
		// Show score on top-right corcer
		if (!GameController.gameOver) {
			timeText.text = "Time: " + GameController.gameTime.ToString ("0.0");
			if (GameController.gameTime < timeWarning) {
				timeText.color = Color.red;
			}
		} else {
			timeText.text = "";
		}
	}
}
