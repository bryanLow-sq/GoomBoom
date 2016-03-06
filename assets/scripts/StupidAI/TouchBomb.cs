using UnityEngine;
using System.Collections;

public class TouchBomb : MonoBehaviour {

	GameObject GM;
	GameManager GMScript;

	void Start()
	{
		GM = GameObject.Find ("GameManager");
		GMScript = GM.GetComponent<GameManager> ();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		
		if (col.gameObject.tag == "Bomb") 
		{
			//Debug.Log ("Touched Bomb");
            GMScript.goomsKilled += 1;
            GMScript.goomsCount -= 1;
			Destroy (this.gameObject);
		}
		
	}
}

