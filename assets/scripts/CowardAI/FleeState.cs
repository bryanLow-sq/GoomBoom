/*Done by: Shing Wei Hao (1400120J), P02
 * Coward AI scripts for Goom Boom
 */

using UnityEngine;
using System.Collections;

public class FleeState : IEnemyState {

	private readonly StatePattern_CowardAI CowardAI;
	int RandomWayPoint;
	bool randomOnlyOnce = false; // Boolean variable, to check that the Flee method is only called once (so that waypoints wont constantly be changed by Update())

	public FleeState (StatePattern_CowardAI statePattern_CowardAI)
	{
		CowardAI = statePattern_CowardAI;
	}

	public void UpdateState()
	{
		Flee();
	}

	public void Execute()
	{
		CowardAI.currentState = CowardAI.lookoutState;
		Debug.Log ("CowardAI: Transitioning to Lookout State");
	}

	void PanicAndDie()
	{
		CowardAI.currentState = CowardAI.dieState;
		Debug.Log ("CowardAI: AI has panicked, Transitioning to Die State");
	}

	void FleeTowardsWayPoint()
	{
		RandomWayPoint = Random.Range (0, CowardAI.FleeWayPoints.Length);
		CowardAI.agent.SetDestination(CowardAI.FleeWayPoints[RandomWayPoint].position);
	}

	void CheckDestination()
	{
		if (CowardAI.transform.position.x == CowardAI.FleeWayPoints [RandomWayPoint].position.x && 
			CowardAI.transform.position.z == CowardAI.FleeWayPoints [RandomWayPoint].position.z)
			Execute ();
	}

	void Flee()
	{
		if (randomOnlyOnce == false) 
		{
			float randomPercentage = Random.value;
			Debug.Log (randomPercentage);
			if (randomPercentage <= 0.1f) // 10% chance for AI to Panic and Die
			{
				PanicAndDie ();
				randomOnlyOnce = true;
			}
			else if (randomPercentage > 0.1f) // 90% chance for AI to Flee to one of the escape waypoints
			{
				if (randomOnlyOnce == false) 
				{
					FleeTowardsWayPoint ();
					randomOnlyOnce = true;
				}
			}
		}
		CheckDestination ();
	}
}
