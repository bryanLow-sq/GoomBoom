using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour 
{

	public float searchingDuration = 4f;
	public float sightRange = 20f;
	public Transform[] waypoints;
	public Vector3 offset = new Vector3 (0, 5f, 0);

	SentryState fsmScanArea;
	SentryState fsmPursue;
	SentryState fsmAttack;
	SentryState fsmCheckForFootPrint;
	SentryState fsmIncreaseAreaScan;
	SentryState fsmRetreat;
	SentryState fsmDie;

	SentryState Currentstate;
	SentryState PreviousState;
	
	public GameObject Player;
	public NavMeshAgent agent;

	[HideInInspector]public GameObject GM;
	[HideInInspector]public GameManager GMScript;

	public enum States
	{
		ScanArea, Pursue, Attack, CheckFootPrint, IncreaseAreaScan, Retreat, Die, Previous
	}


	// Use this for initialization
	void Start () 
	{
		// Find player and store in gameobject first
		Player = GameObject.Find ("Player");
		
		// Get our navmeshagent
		agent = gameObject.GetComponent<NavMeshAgent>();
	
		fsmScanArea = new ScanArea (this);
		fsmPursue = new SentryPursue (this);
		fsmAttack = new SentryAttack (this);
		fsmCheckForFootPrint = new CheckForFootPrint (this);
		fsmIncreaseAreaScan = new IncreaseAreaScan (this);
		fsmRetreat = new Retreat (this);
		fsmDie = new SentryDie (this);

        ChangeStateTo(States.ScanArea);

		GM = GameObject.Find ("GameManager");
		GMScript = GM.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Currentstate != null)
			Currentstate.Execute();

		transform.eulerAngles = new Vector3 (90f, 0f, 0f);
	}

	public void ChangeStateTo (States _nextState)
	{
		if (Currentstate != null)
			Currentstate.Exit ();
		
		switch (_nextState) 
		{
		case States.ScanArea:
			Currentstate = fsmScanArea;
			break;
		case States.Pursue:
			Currentstate = fsmPursue;
			break;
		case States.Attack:
			Currentstate = fsmAttack;
			break;
		case States.IncreaseAreaScan:
			Currentstate = fsmIncreaseAreaScan;
			break;
		case States.Retreat:
			Currentstate = fsmRetreat;
			break;
		case States.Die:
			Currentstate = fsmDie;
			break;
		case States.CheckFootPrint:
			PreviousState = Currentstate;
			Currentstate = fsmCheckForFootPrint;
			break;
		case States.Previous:
			Currentstate = PreviousState;
			break;
			
		default:
			Currentstate = fsmScanArea;
			break;
		}
		
		if (Currentstate != null)
			Currentstate.Enter ();
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "BOMB") 
		{
			ChangeStateTo(FSM.States.Die);
		}
	}
}
