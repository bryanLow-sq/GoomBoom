using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Texture backgroundTexture;
	
	public void OnGUI()
	{	
		GUI.DrawTexture (new Rect (0, 0, Screen.width+50, Screen.height), backgroundTexture);

		if (Input.GetMouseButtonDown(0))
			Application.LoadLevel ("2.2.2016");
	}
}