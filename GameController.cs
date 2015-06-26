using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	//public GameObject hazard;
	public Vector3 spawnValues;
	//public int hazardCount;
	//public float spawnWait;
	//public float startWait;
	//public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText finalScoreText;

	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		finalScoreText.text = "";
		score = 0;
		UpdateScore ();
		//StartCoroutine (SpawnWaves ());
		StartCoroutine (EachSecond ());
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
//	IEnumerator SpawnWaves ()
//	{
//		//yield return new WaitForSeconds (startWait);
//		while (true)
//		{
//			for (int i = 0; i < hazardCount; i++)
//			{
//				Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
//				Quaternion spawnRotation = Quaternion.identity;
//				Instantiate (hazard, spawnPosition, spawnRotation);
//				yield return new WaitForSeconds (spawnWait);
//
//			}
//
//
//			if (gameOver)
//			{
//				restartText.text = "Press 'R' for Restart";
//				restart = true;
//				break;
//			}
//
//
//		}
//	}

	IEnumerator EachSecond ()
	{
		yield return new WaitForSeconds(1);
		while (!gameOver)
		{
			AddScore(1);
			yield return new WaitForSeconds(1);


		}
	}


	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOver = true;
		restart = true;
		Invoke("SetGameOverText",2 );
	}

	public void SetGameOverText()
	{
		gameOverText.text = "You died!";
		restartText.text = "Press <space> to try again";
		finalScoreText.text = "Final score = "+score+" secs";
	}

}