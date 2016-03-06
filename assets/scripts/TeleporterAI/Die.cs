using UnityEngine;
using System.Collections;

public class TDie : FSM_States {
	
	public TDie (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	
	public override void Enter()	{
		//Debug.Log("Entering die state");
	}
	
	public override void Execute()	{
        //destroys the instance of the AI
        oFSM.GMScript.goomsKilled += 1;
        oFSM.GMScript.goomsCount -= 1;
		GameObject.Destroy(oFSM.gameObject);
	}
}
