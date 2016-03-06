using UnityEngine;
using System.Collections;

public class Attack : FSM_States {

	public Attack (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	
	public override void Enter()	{
		//Debug.Log("Entering attack state");
	}
	
	public override void Execute()	{
        UrgentTransition();
		//Debug.Log("Play Attack animation");
        //remove some of the player's HP
        FSM_Overhead.nPHP -= 1;
        Transition();
	}
	
	public override void Exit()	{
		//Debug.Log("Leaving Attack State");
	}

    public override void Transition() {
        if (LineOfSight.bSeen == false)
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.lookAround);
    }

    public override void UrgentTransition() {
        if (FSM_Overhead.nHP <=0)
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.die);

        else 
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.pursue);
    }
}
