using UnityEngine;
using System.Collections;

public class TeleportInFrontPlayer : FSM_States {
	
	public TeleportInFrontPlayer (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	
	public override void Enter()	{
		//Debug.Log("Entering teleport in front of player state");
	}
	
	public override void Execute()	{
		
        if (FSM_Overhead.bHasTPToPlayer) {
            //Debug.Log("Play Teleport animation");

            //Teleports ai in front of player 
            oFSM.gameObject.transform.position +=  (oFSM.player.transform.forward * 7);

            //Turns ai to face player
            oFSM.gameObject.transform.forward = -oFSM.player.transform.forward;

            FSM_Overhead.bHasTPToPlayer = false;
        }
        Transition();
        UrgentTransition();
	}
	
	public override void Exit()	{
		
		//Debug.Log("Leaving Teleport Player State");
	}

    public override void Transition() {
        if (LineOfSight.bSeen == false)
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.lookAround);
    }

    public override void UrgentTransition() {

        if (LineOfSight.bSeen && Vector3.Distance(oFSM.gameObject.transform.position, oFSM.player.transform.position) < 3f)
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.attack);

        else 
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.pursue);
    }
}
