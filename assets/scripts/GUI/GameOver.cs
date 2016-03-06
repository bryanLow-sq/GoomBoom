using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Texture gameOverTexture;

	public void OnGUI()
	{	
		GUI.DrawTexture (new Rect (0, 0, Screen.width+50, Screen.height), gameOverTexture);
		
		if (GUI.Button (new Rect (100, 500, 350, 50), "Restart"))
			Application.LoadLevel ("2.2.2016");

		if (GUI.Button (new Rect (100, 575, 350, 50), "Return to Main Menu")) 
			Application.LoadLevel ("MainMenu");
			                   
		if (GUI.Button (new Rect (100, 650, 350, 50), "Quit"))
			Application.Quit ();
	}
}
