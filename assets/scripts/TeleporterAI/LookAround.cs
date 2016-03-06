using UnityEngine;
using System.Collections;

public class LookAround : FSM_States {

	public LookAround (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	
	public override void Enter()	{
		//Debug.Log("Entering lookAround state");
	}

	public override void Execute()	{

        UrgentTransition();

        Transition();
    }

	public override void Exit()	{
		
        //Debug.Log("Leaving lookAround State");
    }

    public override void Transition() {
        int nRandom = (int)Random.Range (1, 11);

        //else if the player is not seen and the rng is within this range, shift to read state
        if (LineOfSight.bSeen == false && nRandom >= 10)
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.readBook);
           
        //if the roll is not 10, proceed to patrol area
        else 
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.patrolArea);
    }

    public override void UrgentTransition() {
        //Used if conditionan happen in middle of state 

        //if HP is 0, dead
        if (FSM_Overhead.nHP <=0)
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.die);

        //if player is seen during this state, start pursue
		else if (LineOfSight.bSeen)
            oFSM.ChangeStateTo(FSM_Overhead.listOfStates.pursue);

        //else if the AI hears the bomb go into shock
        else if (FSM_Overhead.bHasBombExploded)
            oFSM.ChangeStateTo (FSM_Overhead.listOfStates.shock);
    }
}
