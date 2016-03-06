using UnityEngine;
using System.Collections;

public class SentryPursue : SentryState
{

    public SentryPursue(FSM _SentryFsm)
    {
        SentryFsm = _SentryFsm;
    }

    public override void Enter()
    {
        //Debug.Log("Chasing");
    }

    public override void Execute()
    {
        float distanceToPlayer = Vector3.Distance(SentryFsm.Player.gameObject.transform.position, SentryFsm.gameObject.transform.position);
        if (distanceToPlayer < 0.1f)
        {
            SentryFsm.ChangeStateTo(FSM.States.Attack);
        }

        // Check if a bomb exploded nearby
        /*GameObject[] bombs = GameObject.FindGameObjectsWithTag("BOMB");
        foreach (GameObject bomb in bombs)
        {
            float distanceToBomb = Vector3.Distance(bomb.gameObject.transform.position, SentryFsm.gameObject.transform.position);
            if (distanceToBomb < 10.0f)
            {
                SentryFsm.ChangeStateTo(FSM.States.Retreat);
            }
        }*/

        // Go towards player
        /*
		Vector3 towardsPlayer = SentryFsm.Player.gameObject.transform.position - SentryFsm.gameObject.transform.position;
		towardsPlayer.Normalize();
		SentryFsm.gameObject.transform.Translate(towardsPlayer * 2.0f * Time.deltaTime);
		*/

        // Using navmeshagent
        SentryFsm.agent.SetDestination(SentryFsm.Player.gameObject.transform.position);

    }

    public override void Exit()
    {
        //Debug.Log("Exit Pursue");
    }


}
