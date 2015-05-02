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
	public float gameTime;

	public GameObject coin;
	public static bool gameOver = false;
	public static int score = 0;
	
	void Start ()
	{
		StartCoroutine (SpawnWaves (hazard, 0.0f));
		StartCoroutine (SpawnWaves (coin, startWaitCoins));
	}

	IEnumerator CountGameTime () {
		yield return new WaitForSeconds (gameTime);
		gameOver = true;
	}

	IEnumerator SpawnWaves (GameObject obj, float startWait)
	{
		yield return new WaitForSeconds (startWait);
		while (!gameOver)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (
					Random.Range (-spawnValues.x, spawnValues.x),
					Random.Range(0, spawnValues.y),
					spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (obj, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}