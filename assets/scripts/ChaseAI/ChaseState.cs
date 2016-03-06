using UnityEngine;
using System.Collections;

public interface ChaseState
{
	void UpdateState();
	
	void Transition();
}

