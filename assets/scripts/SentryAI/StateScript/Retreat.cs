using UnityEngine;
using System.Collections;

public class Retreat : SentryState
{
    public Retreat(FSM _SentryFsm)
	{
		SentryFsm = _SentryFsm;
	}
	
	public override void Enter()
	{
        
        //Debug.Log ("Enter Retreat");
	}
	
	public override void Execute()
	{
        var range = Random.Range(0, 4);
        if (range == 0)
        {
            SentryFsm.ChangeStateTo(FSM.States.IncreaseAreaScan);
        }
        else
        {
            SentryFsm.ChangeStateTo(FSM.States.ScanArea);
        }
	}
	
	public override void Exit()
	{
		
	}
}
