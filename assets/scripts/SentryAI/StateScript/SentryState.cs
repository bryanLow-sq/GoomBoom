using UnityEngine;
using System.Collections;

public abstract class SentryState
{
	public FSM SentryFsm;

	public virtual void Enter() { }

	public virtual void Execute() {	}

	public virtual void Exit() { }

}
