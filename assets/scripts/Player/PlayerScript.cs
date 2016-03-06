using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 5.0f;
	Vector3 TargetPos;

	GameObject GM;
	GameManager GMScript;
	Quaternion rotation = Quaternion.Euler (90, 0, 0);

	void Start()
	{
		TargetPos = transform.position;

		GM = GameObject.Find ("GameManager");
		GMScript = GM.GetComponent<GameManager> ();
	} 
	
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
            Vector3 MousePos = Input.mousePosition;
            MousePos.z = Camera.main.transform.position.y;
			TargetPos = Camera.main.ScreenToWorldPoint(MousePos);
			TargetPos.y = -1.5443f;
		}
		transform.position = Vector3.MoveTowards(transform.position, TargetPos, (speed*Time.deltaTime));

		if(Input.GetKeyDown("space"))
		{
			if(GMScript.bomb > 0)
			{
				Instantiate(Resources.Load("bomb"), transform.position, rotation);
				GMScript.bomb--;
			}
			else if (GMScript.bomb == 0)
				Debug.Log ("Cannot place any more bombs!");
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "AI") 
		{
			GMScript.gameOver = true;
			//Debug.Log ("Player is dead");
		}
	}
}
