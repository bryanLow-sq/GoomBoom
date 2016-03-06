using UnityEngine;
using System.Collections;

public class Pursue : FSM_States {

    // The point to move to - in this case, the player
    public Transform player;

    // The AI's speed per second
    public float speed = 5;

	public Pursue (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	//transition to teleport counter
    public float counter = 0.0f;

    public void InstantiateVariables()
    {
        player = oFSM.player.transform;

        //Debug.Log ("Pursue Start has been started");
    }

	public override void Enter()	{
		//Debug.Log("Entering pursue state");
	}
	
	public override void Execute()	{
		 
        //Debug.Log("Enter pursuit");
        if (FSM_Overhead.bStartedPursuit == false) {
            InstantiateVariables();

            //this is done to prevent the function from being called until the script is entered again
            FSM_Overhead.bStartedPursuit = true;
            //Debug.Log("Pursue Start has been started");
        }
        
        Transition();

		oFSM.gameObject.GetComponent<NavMeshAgent>().SetDestination(oFSM.player.transform.position);
        
        counter += Time.deltaTime;
        UrgentTransition();
	}
	
	public override void Exit()	{
		//Debug.Log("Leaving Pursue State");
	}

    public override void Transition() {
        
        if (LineOfSight.bSeen == false) {
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.lookAround);
            FSM_Overhead.bStartedPursuit = false;
            counter = 0.0f;
        }
    }

    public override void UrgentTransition() {

        if (FSM_Overhead.nHP <=0) {
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.die);
            FSM_Overhead.bStartedPursuit = false;
            counter = 0.0f;
        }

        //if the ai is near the player, go into attack mode
        else if (Vector3.Distance(oFSM.gameObject.transform.position, player.position) < 3f) {
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.attack);
            FSM_Overhead.bStartedPursuit = false;
            counter = 0.0f;
        }

        //After a certain amt of time has passed, go to teleport state
        else if (counter >= 5.0f) {
            counter = 0.0f;
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.teleportInFrontPlayer);
            FSM_Overhead.bStartedPursuit = false;
            FSM_Overhead.bHasTPToPlayer = true;
        }
    }
}
