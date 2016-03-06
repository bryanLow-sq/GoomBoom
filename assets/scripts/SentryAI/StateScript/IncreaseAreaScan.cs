using UnityEngine;
using System.Collections;

public class IncreaseAreaScan : SentryState 
{
	public IncreaseAreaScan(FSM _SentryFsm)
	{
		SentryFsm = _SentryFsm;
	}
	
	public override void Enter()
	{
		//Debug.Log ("Player not found. IncreaseAreaScan");
	}
	
	public override void Execute()
	{
        float Scanning = Vector3.Distance(SentryFsm.Player.gameObject.transform.position, SentryFsm.gameObject.transform.position);

        if (Scanning < 20.0f)
        {
            SentryFsm.ChangeStateTo(FSM.States.Pursue);
        }
        else
        {
            SentryFsm.ChangeStateTo(FSM.States.CheckFootPrint);
        }
        
	}
	
	public override void Exit()
	{

	}
}
