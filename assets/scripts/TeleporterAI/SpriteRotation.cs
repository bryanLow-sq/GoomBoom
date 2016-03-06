using UnityEngine;
using System.Collections;

public class SpriteRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.eulerAngles = new Vector3(90f, 0f, 0f);
	}
}
