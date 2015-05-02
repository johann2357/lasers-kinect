using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopingTextController : MonoBehaviour {

	public float scrollSpeed;
	public float life;
	public bool subir;

	private Text text;

	void Awake() {
		text = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (text.color.a > 0) {
			Vector3 tempPos = transform.position;
			if (subir) {
				tempPos.y += scrollSpeed * Time.deltaTime;
			} else {
				tempPos.y -= scrollSpeed * Time.deltaTime;
			}
			transform.position =  tempPos;

			Color tempColor = text.color;
			tempColor.a -= Time.deltaTime / life;
			text.color = tempColor;
		} else {
			Destroy (gameObject);
		}
	}
}
