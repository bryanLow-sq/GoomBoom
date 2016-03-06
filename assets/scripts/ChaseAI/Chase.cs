using UnityEngine;
using System.Collections;

public class Chase : ChaseState {

	private readonly ChaseFSM ChaseAI;
	float timer = 0f;

	public Chase (ChaseFSM chaseAI)
	{
		ChaseAI = chaseAI;
	}

	public void UpdateState()
	{
		_Chase();
	}
	
	public void Transition()
	{
		//Debug.Log ("Transitioning to Adrenaline State");
		ChaseAI.currentState = ChaseAI.adrenaline;
	}
	
	public void _Chase()
	{
		timer += Time.deltaTime;
		ChaseAI.agent.SetDestination (ChaseAI.target.transform.position);
		ChaseAI.transform.eulerAngles = new Vector3(90f, 0f, 0f);

		if (timer >= 10.0f) 
		{
			float rand = Random.value; //random the delay between spawn times
			if (rand <= 0.25) 
			{
				//Debug.Log ("Randomed value is " +rand+ ", Transitioning to Adrenaline State"); 
				Transition ();
			}
			else 
			{
				//Debug.Log("Randomed value is " +rand+ ", Staying in Chase State"); 
				timer = 0.0f;
			}
		}
	}
}
