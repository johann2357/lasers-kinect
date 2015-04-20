using UnityEngine;
using System.Collections;

public class VoiceRecognitionUI : MonoBehaviour {

	public float speed=1.0f;
	public Transform start;
	public Transform end;
	private SpeechManager speechManager;
	private float startTime;
	private float journeyLength;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(speechManager == null)
		{
			speechManager = SpeechManager.Instance;
		}
		
		if(speechManager != null && speechManager.IsSapiInitialized())
		{
			if(speechManager.IsPhraseRecognized())
			{
				string sPhraseTag = speechManager.GetPhraseTagRecognized();
				print (sPhraseTag);
				if (sPhraseTag=="PLAY")
				{
					Application.LoadLevel("Cajitas");
					Destroy(gameObject);
				}

			}
		}
	
	
	}
}
