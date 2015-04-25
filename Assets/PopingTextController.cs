using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopingTextController : MonoBehaviour {

	public Color color;
	public float scrollSpeed;
	public float life;
	public float alfa;
	public bool subir;
	private Text myText;

	void Awake() {
		myText = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		myText.material.color = color;
		alfa = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (alfa > 0) {
			Vector3 tempPos = transform.position;
			if (subir) {
				tempPos.y += scrollSpeed * Time.deltaTime;
			} else {
				tempPos.y -= scrollSpeed * Time.deltaTime;
			}
			transform.position =  tempPos;
			alfa -= Time.deltaTime / life;
			Color tempColor = myText.material.color;
			tempColor.a = alfa;
			myText.material.color = tempColor;
		} else {
			Destroy (gameObject);
		}
	}
}
