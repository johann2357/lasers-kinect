using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {
	public Text timeText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateTime ();
	}

	private void updateTime() {
		// Show score on top-right corcer
		timeText.text = "Time: " + GameController.gameTime.ToString ("0.0");
	}
}
