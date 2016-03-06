using UnityEngine;
using System.Collections;

public class PatrolArea : FSM_States {
	
    Animator m_Animator;

	public PatrolArea (FSM_Overhead _FSM) {
		oFSM = _FSM;
	}
	
	public override void Enter()	{
		//Debug.Log("Entering patrol area state");
		oFSM.target = oFSM.target.GetComponent<GizmoPosition>().mNextWaypoints[0];
	}
	
	public override void Execute() {


		//Debug.Log ("Beginning Patrol");
        UrgentTransition();

        oFSM.gameObject.GetComponent<NavMeshAgent>().SetDestination(oFSM.target.position);

	    // Reached the end of the path
        if (Vector3.Distance(oFSM.gameObject.transform.position, oFSM.target.transform.position) <= 5/*&& FSM_Overhead.bStartedPatrol*/)
        {
            //FSM_Overhead.bStartedPatrol = false;
			oFSM.gameObject.GetComponent<NavMeshAgent>().ResetPath();
            Transition();
        }
	}

	public override void Exit()	{
		
		//Debug.Log("Leaving PatrolArea State");

	}

    public override void Transition() {

        //start looking around current position
        oFSM.ChangeStateTo (FSM_Overhead.listOfStates.lookAround);
		//oFSM.target = oFSM.target.GetComponent<GizmoPosition>().mNextWaypoints[0];
    }

    public override void UrgentTransition() {

        //if AI HP <= 0 it is dead
        if (FSM_Overhead.nHP <= 0) {
			oFSM.ChangeStateTo (FSM_Overhead.listOfStates.die);
			//oFSM.target = oFSM.target.GetComponent<GizmoPosition> ().mNextWaypoints [0];
		}
        //if player is seen
        else if (LineOfSight.bSeen == true) {
			oFSM.ChangeStateTo (FSM_Overhead.listOfStates.pursue);
			//oFSM.target = oFSM.target.GetComponent<GizmoPosition> ().mNextWaypoints [0];
		}
        //else if the AI hears the bomb go into shock
        else if (FSM_Overhead.bHasBombExploded) {
			oFSM.ChangeStateTo (FSM_Overhead.listOfStates.shock);
			//oFSM.target = oFSM.target.GetComponent<GizmoPosition> ().mNextWaypoints [0];
		}
    }
}
