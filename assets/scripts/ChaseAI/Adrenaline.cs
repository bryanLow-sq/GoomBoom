using UnityEngine;
using System.Collections;

public class Adrenaline : ChaseState {

	private readonly ChaseFSM ChaseAI;

	float timer = 0f;

	public Adrenaline (ChaseFSM chaseAI)
	{
		ChaseAI = chaseAI;
	}

	public void UpdateState()
	{
		_Adrenaline();
	}

	public void Transition()
	{
		ChaseAI.currentState = ChaseAI.die;
		//Debug.Log ("Transitioning to Die State");
	}

	public void _Adrenaline()
	{
		ChaseAI.agent.speed = 5f;
		ChaseAI.agent.SetDestination (ChaseAI.target.transform.position);
		ChaseAI.transform.eulerAngles = new Vector3(90f, 0f, 0f);
		timer += Time.deltaTime;
		if (timer >= 10f)
			Transition ();
	}
}
