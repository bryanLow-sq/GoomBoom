/*Done by: Shing Wei Hao (1400120J), P02
 * Coward AI scripts for Goom Boom
 */

using UnityEngine;
using System.Collections;

public class DieState : IEnemyState {
	
	private readonly StatePattern_CowardAI CowardAI; // Reference to AI in StatePattern script
	float TimeElapsed = 0f; // Time elapsed
	
	public DieState (StatePattern_CowardAI statePattern_CowardAI)
	{
		CowardAI = statePattern_CowardAI;
	}

	public void UpdateState()
	{
		Die();
	}

	public void Execute()
	{
	}
	
	private void Die()
	{
		TimeElapsed += Time.deltaTime; // Time elapsed according to the game world

		if (TimeElapsed > 3f) 
			CowardAI.die = true; 
	}
}
