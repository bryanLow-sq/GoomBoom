using UnityEngine;
using System.Collections;

public class FSM_Overhead : MonoBehaviour {

	//the states
	FSM_States fsmLookAround;
	FSM_States fsmPatrolArea;
	FSM_States fsmReadBook;
	FSM_States fsmShock;
	FSM_States fsmTeleportToBomb;
	FSM_States fsmPursue;
	FSM_States fsmAttack;
	FSM_States fsmTeleportInFrontPlayer;
	FSM_States fsmDie;

	[HideInInspector]public GameObject GM;
	[HideInInspector]public GameManager GMScript;

	//pointer for current state
	FSM_States fsmCurrentState;
    //HP for AI
    public static int nHP = 1;
    //HP for player
    public static int nPHP = 1;
    
    //variable to check for patrol start
    //public static bool bStartedPatrol;

    public Transform target;

    public static Vector3 bombPlacement;

    public GameObject player;

    public static bool bHasBombExploded = false;

    public static bool bStartedPursuit = false;

    public static bool bHasTPToPlayer = false;

    public static bool bHasTPToBomb = false;

	public enum listOfStates {
		lookAround,
		patrolArea,
		readBook,
		shock,
		teleportToBomb,
		pursue,
		attack,
		teleportInFrontPlayer,
		die
	}

	// Use this for initialization
	void Start () {
		//initiallizes the 
		fsmLookAround = new LookAround (this);
		fsmPatrolArea = new PatrolArea (this);
		fsmReadBook = new ReadBook (this);
		fsmShock = new Shock (this);
		fsmTeleportToBomb = new TeleportToBomb (this);
		fsmPursue = new Pursue (this);
		fsmAttack = new Attack (this);
		fsmTeleportInFrontPlayer = new TeleportInFrontPlayer (this);
		fsmDie = new TDie (this);

		ChangeStateTo (listOfStates.lookAround);

		GM = GameObject.Find ("GameManager");
		GMScript = GM.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//ensures that after a new state is loaded it will start executing
		//its task
		if (fsmCurrentState != null)
			fsmCurrentState.Execute ();

		//transform.eulerAngles = new Vector3(90f, 0f, 0f);
	}

	public void ChangeStateTo (listOfStates _next) {
		//sets fsmCurrentState to the current state
		//resets the AI in the case if an error occurs to the default state
		if (fsmCurrentState != null)
			fsmCurrentState.Exit ();

		switch (_next)	{
			case listOfStates.lookAround:
				fsmCurrentState = fsmLookAround;
				break;
            case listOfStates.patrolArea:
				fsmCurrentState = fsmPatrolArea;
				break;
			case listOfStates.readBook:
				fsmCurrentState = fsmReadBook;
				break;
			case listOfStates.shock:
				fsmCurrentState = fsmShock;
				break;
            case listOfStates.teleportToBomb:
                fsmCurrentState = fsmTeleportToBomb;
                break;
            case listOfStates.pursue:
                fsmCurrentState = fsmPursue;
                break;
            case listOfStates.attack:
                fsmCurrentState = fsmAttack;
                break;
            case listOfStates.teleportInFrontPlayer:
                fsmCurrentState = fsmTeleportInFrontPlayer;
                break;
            case listOfStates.die:
                fsmCurrentState = fsmDie;
                break;
        }
		if (fsmCurrentState != null) {
			fsmCurrentState.Enter();
		}
	}
}