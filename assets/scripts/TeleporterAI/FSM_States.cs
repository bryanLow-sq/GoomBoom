using UnityEngine;
using System.Collections;

public abstract class FSM_States {
	
	//sets a pointer for this FSM_Overhead
	public FSM_Overhead oFSM;
	
    public virtual void Enter() {}

    public virtual void Execute() {}

    public virtual void Exit() {}
    //helps to transition to next state
    public virtual void Transition() {}
    //used in place of Transition() if condition can interupt current state
    public virtual void UrgentTransition() {}
}
