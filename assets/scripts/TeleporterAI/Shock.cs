using UnityEngine;
using System.Collections;

public class Shock : FSM_States {
	
	public Shock (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	
	public override void Enter()	{
		//Debug.Log("Entering shock state");
	}
	
	public override void Execute()	{
		
        UrgentTransition();
        Transition();
        
	}
	
	public override void Exit()	{
		//Debug.Log("Exiting Shock State");
	}

    public override void Transition() {
        
        //if HP of AI is 0
        if (FSM_Overhead.nHP <=0)
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.die);

        else 
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.teleportToBomb);
    }
}