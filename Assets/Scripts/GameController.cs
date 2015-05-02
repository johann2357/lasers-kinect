using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWaitCoins;
	public float waveWait;
	public static float gameTime = 10;

	public GameObject coin;
	public static bool gameOver = false;
	public static int score = 0;
	
	void Start ()
	{
		StartCoroutine (SpawnWaves (hazard, 0.0f));
		StartCoroutine (SpawnWaves (coin, startWaitCoins));
		StartCoroutine (CountGameTime ());
	}

	IEnumerator CountGameTime () {
		while (gameTime >= 0.1f) {
			gameTime -= 0.1f;
			yield return new WaitForSeconds (0.1f);
		}
		gameOver = true;
	}

	IEnumerator SpawnWaves (GameObject obj, float startWait)
	{
		yield return new WaitForSeconds (startWait);
		while (!gameOver)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				if (!gameOver) {
					Vector3 spawnPosition = new Vector3 (
						Random.Range (-spawnValues.x, spawnValues.x),
						Random.Range(0, spawnValues.y),
						spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (obj, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
			}
			if (!gameOver) {
				yield return new WaitForSeconds (waveWait);
			}
		}
	}
}