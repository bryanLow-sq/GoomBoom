/*Done by: Shing Wei Hao (1400120J), P02
 * Coward AI scripts for Goom Boom
 */

using UnityEngine;
using System.Collections;

public class LookoutState : IEnemyState {

	private readonly StatePattern_CowardAI CowardAI; // Reference to AI in StatePattern script
	float TimeElapsed = 0f; // Time elapsed

	public LookoutState (StatePattern_CowardAI statePattern_CowardAI)
	{
		CowardAI = statePattern_CowardAI;
	}

	public void UpdateState()
	{
		Lookout ();
	}
	
	public void Execute()
	{
		CowardAI.currentState = CowardAI.checkSurroundingState;
		Debug.Log ("Transitioning to CheckSurrounding State");
		CowardAI.PatrolTime = 20.0f;
	}

	private void Lookout()
	{
		TimeElapsed += Time.deltaTime; // Time elapsed according to the game world

		if (TimeElapsed > 15f && CowardAI.dontTransition == false) // CowardAI will attempt to detect player in lookout state for 15 seconds
			Execute ();
	}
}
