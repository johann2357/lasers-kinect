using UnityEngine;
using System.Collections;

public class StoryController : MonoBehaviour {

	public float fadeSpeed = 1.0f;
	public float showItemTime = 2.0f;

	private CanvasGroup cv;

	// Use this for initialization
	void Start () {
		cv = gameObject.GetComponent<CanvasGroup>();
		StartCoroutine (TellStory ());
	}

	IEnumerator TellStory() {
		for (int i = 0; i < transform.childCount; ++i) {
			transform.GetChild(i).gameObject.SetActive(false);
		}

		transform.GetChild(0).gameObject.SetActive(true);
		yield return new WaitForSeconds (showItemTime);

		for (int i = 1; i < transform.childCount; ++i) {
			//FadeOut ();
			transform.GetChild(i).gameObject.SetActive(true);
			transform.GetChild(i-1).gameObject.SetActive(false);
			//FadeIn ();
			yield return new WaitForSeconds (showItemTime);
		}
		//Destroy (gameObject);
		Application.LoadLevel("Cajitas");

		//FadeOut ();
	}

	void FadeOut() {
		float prev = Time.time;
		while (cv.alpha > 0) {
			float cur = Time.time;
			cv.alpha -= fadeSpeed*(cur-prev);
			prev = cur;
		}
	}

	void FadeIn() {
		float prev = Time.time;
		while (cv.alpha < 1) {
			float cur = Time.time;
			cv.alpha += fadeSpeed*(cur-prev);
			prev = cur;
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
