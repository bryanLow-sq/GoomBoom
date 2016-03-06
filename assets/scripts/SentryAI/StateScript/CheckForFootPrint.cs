using UnityEngine;
using System.Collections;

public class CheckForFootPrint : SentryState
{ 
	private float timer;

	public CheckForFootPrint(FSM _SentryFsm)
	{	
		SentryFsm = _SentryFsm;
	}
	
	public override void Enter()
	{
		timer = 0.0f;
		//Debug.Log ("Entering CheckForFootPrint State");
        SentryFsm.waypoints[0] = SentryFsm.waypoints[0].GetComponent<GizmoPosition>().mNextWaypoints[0];
	}
	
	public override void Execute()
	{
        SentryFsm.gameObject.GetComponent<NavMeshAgent>().SetDestination(SentryFsm.waypoints[0].position);
		// After 5 seconds, go to ScanArea
		timer += Time.deltaTime;
		if (timer >= 5.0f)
		{
			SentryFsm.ChangeStateTo(FSM.States.ScanArea);
		}
		
	}
	
	public override void Exit()
	{
		//Debug.Log ("Exiting CheckForFootPrint State");
	}
}
