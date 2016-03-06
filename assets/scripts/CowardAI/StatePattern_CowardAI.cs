/*Done by: Shing Wei Hao (1400120J), P02
 * Coward AI scripts for Goom Boom
 */

using UnityEngine;
using System.Collections;

public class StatePattern_CowardAI : MonoBehaviour 
{
	[HideInInspector]public bool die = false; // To check if AI has died or not
	[HideInInspector]public bool EnemyDetected = false; // To detect enemy collisions (for checkSurroundingState only)
	[HideInInspector]public bool dontCollideAgain = false; // To avoid duplicate collisions
	[HideInInspector]public bool dontTransition = false; // Prevent other state transition (in case AI has collided with player while in lookOut State)
	[HideInInspector]public NavMeshAgent agent; 
	[HideInInspector]public float PatrolTime = 20f;  // Timer for AI to change waypoints

	// State variables created according to its names
	public IEnemyState currentState;
	public CheckSurroundingState checkSurroundingState;
	public DieState dieState;
	public FleeState fleeState;
	public LookoutState lookoutState;

	// Transform arrays of WayPoints for different states
	public Transform[] CheckSurroundingWayPoints;
	public Transform[] FleeWayPoints;

	// To access GoomsDestroyed counter
	GameObject GM;
	GameManager GMScript;
	
	void Awake() 
	{
		checkSurroundingState = new CheckSurroundingState (this);
		dieState = new DieState (this);
		fleeState = new FleeState (this);
		lookoutState = new LookoutState (this);
	}
	
	void Start () 
	{
		currentState = checkSurroundingState; // AI will begin with checkSurrounding state
		agent = GetComponent<NavMeshAgent> ();

		GM = GameObject.Find ("GameManager");
		GMScript = GM.GetComponent<GameManager> ();
	}

	void Update () 
	{
		currentState.UpdateState (); // Constantly updates status of AI
		transform.eulerAngles = new Vector3(90f, 0f, 0f); // Constantly locks x rotation of AI at 90f, as we are using x,z co-ordinates for this game

		if (die == true) 
		{
			Destroy (this.gameObject); // AI will be destroyed
			GMScript.goomsKilled++; // Counter for gooms destroyed
			GMScript.goomsCount--; // Counter for gooms (currently in the game)
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player" && currentState == checkSurroundingState) // For CheckSurrounding Collision 
			EnemyDetected = true; 
	
		if (col.gameObject.name == "Player" && currentState == lookoutState) // For LookOut collision
		{
			dontTransition = true;
			currentState = dieState;
			Debug.Log ("CowardAI: Transitioning to Die State");
		}

		if (col.gameObject.tag == "Bomb")
			die = true;
	}
}
