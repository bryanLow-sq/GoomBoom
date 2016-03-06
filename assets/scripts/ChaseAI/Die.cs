using UnityEngine;
using System.Collections;

public class Die : ChaseState {
	
	private readonly ChaseFSM ChaseAI;
	
	public Die (ChaseFSM chaseAI)
	{
		ChaseAI = chaseAI;
	}
	
	public void UpdateState()
	{
		_Die();
	}
	
	public void Transition()
	{
	}
	
	public void _Die()
	{
		//Debug.Log ("Transition to Die State, AI destroyed");
		ChaseAI.isDead = true;
	}
}
