using UnityEngine;
using System.Collections;

public class BombCol : MonoBehaviour {

	GameObject GM;
	GameManager GMScript;
	bool PlaySound = false;

	void Start()
	{
		GM = GameObject.Find ("GameManager");
		GMScript = GM.GetComponent<GameManager> ();
	}

	IEnumerator OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "AI" || col.gameObject.tag == "CowardAI")
		{
			Destroy(col.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GMScript.audio.Play ();
			yield return new WaitForSeconds(GMScript.audio.clip.length);
			Destroy (this.gameObject);
            GMScript.goomsKilled++;
			GMScript.bomb++;
		}

	}
}
