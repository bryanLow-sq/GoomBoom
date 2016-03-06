using UnityEngine;
using System.Collections;

public class TouchPlayer : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col)
	{
		
		if (col.gameObject.name == "Placeholder_Player") {
			//Debug.Log ("Touched Player");
			col.gameObject.GetComponent<MeshRenderer>().enabled = false;
			col.gameObject.GetComponent<PlayerScript>().enabled = false;
		}
		
	}
}
