/*Done by: Shing Wei Hao (1400120J), P02
 * Coward AI scripts for Goom Boom
 */

using UnityEngine;
using System.Collections;

public class CheckSurroundingState : IEnemyState {

	private readonly StatePattern_CowardAI CowardAI; 
	int RandomWayPoint = 0;

	public CheckSurroundingState (StatePattern_CowardAI statePattern_CowardAI)
	{
		CowardAI = statePattern_CowardAI;
	}

	public void UpdateState()
	{
		CheckSurrounding ();
	}

	public void Execute()
	{
		CowardAI.currentState = CowardAI.fleeState; 
		Debug.Log ("CowardAI: Transitioning to Flee State");
	}

	void Patrolling()
	{
		CowardAI.PatrolTime += Time.deltaTime;

		if (CowardAI.PatrolTime > 20.0f)
		{
			RandomWayPoint = Random.Range (0, CowardAI.CheckSurroundingWayPoints.Length);
			CowardAI.agent.SetDestination(CowardAI.CheckSurroundingWayPoints[RandomWayPoint].position);
			Debug.Log ("CowardAI: Patrolling towards Waypoint " + RandomWayPoint);
			CowardAI.PatrolTime = 0f;
		}
	}

	private void CheckSurrounding()
	{
		Patrolling ();
		if (CowardAI.EnemyDetected == true)
			Execute ();
	}
}
