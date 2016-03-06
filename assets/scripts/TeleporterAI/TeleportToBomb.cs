using UnityEngine;
using System.Collections;

public class TeleportToBomb : FSM_States {
	
	public TeleportToBomb (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	
	public override void Enter()	{
		//Debug.Log("Entering teleport to bomb state");
	}
	
	public override void Execute()	{
		
        //Debug.Log("Play Teleport animation");
        //move AI directly to the center of the last explosion
        oFSM.gameObject.transform.position = FSM_Overhead.bombPlacement;
        Transition();
        UrgentTransition();
	}
	
	public override void Exit()	{
		//Debug.Log("Leaving TP to Bomb State");
	}

    public override void Transition() {
        //if player is not seen look around
        if (LineOfSight.bSeen == false) {
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.lookAround);
            FSM_Overhead.bHasBombExploded = false;
        }
    }

    public override void UrgentTransition() {

        //if player is seen, chase immediately
        if (LineOfSight.bSeen) {
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.pursue);
            FSM_Overhead.bHasBombExploded = false;
        }
    }
}