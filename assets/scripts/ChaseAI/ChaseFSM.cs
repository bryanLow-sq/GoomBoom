using UnityEngine;
using System.Collections;

public class ChaseFSM : MonoBehaviour {

	[HideInInspector]public ChaseState currentState;
	[HideInInspector]public Adrenaline adrenaline;
	[HideInInspector]public Chase chase;
	[HideInInspector]public Die die;

	[HideInInspector]public bool isDead = false;
	[HideInInspector]public float speed = 3f;

	[HideInInspector]public GameObject target;
	[HideInInspector]public NavMeshAgent agent;

	GameObject GM;
	GameManager GMScript;

	void Start()
	{
		target = GameObject.Find ("Player");
		currentState = chase;
		agent = GetComponent<NavMeshAgent> ();

		GM = GameObject.Find ("GameManager");
		GMScript = GM.GetComponent<GameManager> ();
	}

	void Awake()
	{
		adrenaline = new Adrenaline (this);
		chase = new Chase (this);
		die = new Die (this);
	}

	void Update()
	{
		currentState.UpdateState ();
		transform.eulerAngles = new Vector3(90f, 0f, 0f);

		if (isDead == true)
		{
			Destroy (this.gameObject);
			GMScript.goomsKilled++;
            GMScript.goomsCount -= 1;
		}
	}
}
