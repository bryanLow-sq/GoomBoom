using UnityEngine;
using System.Collections;

public class ScanArea : SentryState
{

	public ScanArea(FSM _SentryFsm)
	{
		SentryFsm = _SentryFsm;
	}

	public override void Enter()
	{
		//Debug.Log ("Activate Scan");
	}

	public override void Execute()
	{
        float Scanning = Vector3.Distance(SentryFsm.Player.gameObject.transform.position, SentryFsm.gameObject.transform.position);
        //Debug.Log("Scanning....");
        if (Scanning < 15.0f) 
		{
			SentryFsm.ChangeStateTo (FSM.States.Pursue);
            //Debug.Log("Player detected");
		} 
	}

	public override void Exit()
	{
        //Debug.Log("Exit Scan");
	}
}
