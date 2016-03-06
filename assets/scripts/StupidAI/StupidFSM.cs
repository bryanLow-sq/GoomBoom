//Adrian Lee 1403287D 
//Stupid AI 6.12.2015



using UnityEngine;
using System.Collections;

public class StupidFSM : MonoBehaviour {

	public float fAIspeed = 2.0f;


	public float fX;
	public float fY;
	public float fZ;
	public bool  bFoundPlayer;
	public GameObject _Player;
	public Vector3 vPlayerPos;
	public DetectPlayer detectScript;
	public bool bIsCollide = false;
	private Vector3 vWayPoint;
	public NavMeshAgent agent;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
		_Player = GameObject.FindWithTag ("Player");
		detectScript = GetComponent<DetectPlayer> ();
		SetWayPoint ();
	}


	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(90f, 0f, 0f);

		if (bFoundPlayer == true && bIsCollide == true) {
			ChasePlayer ();
		} else if (bFoundPlayer == false && bIsCollide == false) {
			Move ();
		}
	}

	

	void Move()
	{
		if (Vector3.Distance(transform.position, vWayPoint) >= 2) {
			MoveToWayPoint ();
		} else {
			SetWayPoint ();//set waypoint
		}
	}
	public void SetWayPoint()
	{
		fX = Random.Range (-20.0f, 20.0f);
		fY = 0f;
		fZ = Random.Range (-20.0f, 20.0f);
		
		vWayPoint = new Vector3 (fX, fY, fZ);

		//Debug.Log ("WayPoint set!");
	}
	public void MoveToWayPoint()
	{
		agent.SetDestination (vWayPoint); //next time do random
		//transform.position = Vector3.MoveTowards (transform.position, vWayPoint, fStep);
		//Debug.Log ("Moving to Waypoint!");
	}

	public void ChasePlayer() //player within radius
	{
		agent.SetDestination (_Player.transform.position);
		//vPlayerPos = new Vector3 (_Player.transform.position.x, 
		 //                         _Player.transform.position.y, 
		 //                        _Player.transform.position.z);
		//transform.position = Vector3.MoveTowards (transform.position, vPlayerPos, fStep);
		//Debug.Log ("Chasing player!");
	}
	
	public void Confuse() //player got into radius and left
	{
		fAIspeed = 0;
		//Debug.Log ("Where did player go?");
		//Display Question Mark Sprite
	}
	public void UnConfuse()
	{	
	
		fAIspeed = 2.0f;
		//Debug.Log ("Let's get back to moving");
	}



}
