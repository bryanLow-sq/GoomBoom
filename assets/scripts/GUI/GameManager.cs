using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class GameManager : MonoBehaviour {

	bool isPaused = false;

	[HideInInspector]public int bomb = 3;  //to make sure the bomb count is max at 3 at all time
	[HideInInspector]public int goomsKilled = 0;
	[HideInInspector]public bool gameOver = false;
	[HideInInspector]public float goomsCount = 0; 

	public AudioSource audio;
	float seconds = 0;
	float minutes = 0;
	float SpawnTiming = 0;
	int randomGoom = 0;
	int randomSpawnPoint = 0;
	GUIText status;


	public GameObject[] Gooms;
	public Transform[] SpawnPoints;
	
	void Start()
	{
		status = GetComponent<GUIText>();
		audio = GetComponent<AudioSource> ();
	}
	
	void OnGUI()
	{
		if (!isPaused) {
			if (GUI.Button (new Rect (10, 10, 100, 50), "Pause")) {
				Time.timeScale = 0f;
				isPaused = true;
			}
		}

		if (isPaused) 
		{
			if (GUI.Button (new Rect (10, 10, 100, 50), "Play")) {
				Time.timeScale = 1.0f;
				isPaused = false;
			}
		}
	}

	void CheckGameOver()
	{
		if (gameOver == true) 
			Application.LoadLevel ("GameOver");
	}

	public void SpawnGoom()
	{
		randomSpawnPoint = Random.Range (0, SpawnPoints.Length);
		randomGoom = Random.Range (0, Gooms.Length);
		Instantiate (Gooms [randomGoom], SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
	}

	void SpawnAI()
	{
		SpawnTiming += Time.deltaTime;

		if (SpawnTiming > 1.0f) // Spawns an AI every 5 seconds
		{
			if (goomsCount < 100)
			{
				SpawnGoom();
				goomsCount++;
			}
			else Debug.Log ("Maximum Gooms Spawned!");

			SpawnTiming = 0.0f;
		}
	}

	void UpdateText()
	{
		status.text = "Gooms Present in Map: " + goomsCount + "\nGooms Destroyed: " + goomsKilled + "\nBombs left: " + bomb + "\nTime Elapsed: " + minutes.ToString ("00") + ":" + Mathf.RoundToInt (seconds).ToString ("00");
	}

	void UpdateTime() 
	{
		seconds += Time.deltaTime; 
		
		if(seconds >= 60) 
		{
			minutes += 1; 
			seconds = 0;
		}
	}

	void Update()
	{
		UpdateTime ();
		UpdateText ();
		SpawnAI ();
		CheckGameOver ();
	}
}
