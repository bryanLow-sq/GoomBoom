//Adrian Lee 1403287D 
//Stupid AI 6.12.2015

using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {

	public GameObject AI;
	//public StupidFSM script;

	void Start()
	{
		//script = AI.GetComponent<StupidFSM> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("I see Player");
			AI.GetComponent<StupidFSM>().bFoundPlayer = true;
			AI.GetComponent<StupidFSM>().bIsCollide = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("I lost Player! @_@");
			AI.GetComponent<StupidFSM>().bFoundPlayer = false;
			AI.GetComponent<StupidFSM>().bIsCollide = false;
			AI.GetComponent<StupidFSM>().Invoke ("Confuse", 0.5f);
			AI.GetComponent<StupidFSM>().Invoke ("UnConfuse",2.0f);

		} 
	}

}
