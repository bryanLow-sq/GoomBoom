using UnityEngine;
using System.Collections;

public class ReadBook : FSM_States {
	
	public ReadBook (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	
	public override void Enter()	{
		//Debug.Log("Entering read book state");
	}
	
	public override void Execute()	{

        UrgentTransition();

        Transition();
	}
	
	public override void Exit()	{
		
		//Debug.Log("Leaving ReadBook State");
	}

    public override void Transition() {

        //start looking around current position
        oFSM.ChangeStateTo (FSM_Overhead.listOfStates.lookAround);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
    }

    public override void UrgentTransition() {
        //if HP is 0, dead
        if (FSM_Overhead.nHP <=0)
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.die);
    }
}
