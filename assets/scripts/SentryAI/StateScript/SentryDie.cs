using UnityEngine;
using System.Collections;

public class SentryDie : SentryState
{

	public SentryDie(FSM _SentryFsm)
	{
		SentryFsm = _SentryFsm;
	}
	
	public override void Enter()
	{
		
	}
	
	public override void Execute()
	{
        SentryFsm.GMScript.goomsKilled += 1;
		SentryFsm.GMScript.goomsCount -= 1;
		GameObject.Destroy(SentryFsm.gameObject);
	}
	
	private void Respawn()
	{
		SentryFsm.ChangeStateTo(FSM.States.CheckFootPrint);
	}
	
	public override void Exit()
	{
		//Debug.Log ("Died");
	}
}
