using UnityEngine;
using System.Collections;

public class SentryAttack : SentryState
{

    public SentryAttack(FSM _SentryFsm)
    {
        SentryFsm = _SentryFsm;
    }

    public override void Enter()
    {
        //Debug.Log("Entering Attack Mode");
    }

    public override void Execute()
    {
        float Hitting = Vector3.Distance(SentryFsm.Player.gameObject.transform.position, SentryFsm.gameObject.transform.position);
        if (Hitting > 5.0f)
        {
            SentryFsm.ChangeStateTo(FSM.States.CheckFootPrint);
        }
    }

    public override void Exit()
    {
        SentryFsm.ChangeStateTo(FSM.States.Previous);
    }
}
