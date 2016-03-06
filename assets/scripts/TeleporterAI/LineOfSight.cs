using UnityEngine;
using System.Collections;

public class LineOfSight : MonoBehaviour {

	private GameObject player;
	public float viewingDist = 7f;
    public static bool bSeen = false;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update() {
		bool bTest = bLOStest (gameObject, player, viewingDist);
        if (bTest) {
            bSeen = true;
        }
        else
            bSeen = false;
	}
	
	public static bool bLOStest (GameObject _source, GameObject _target, float fViewDist) {
		
		Vector3 vectorTargetToSource = _target.transform.position - _source.transform.position;
		//getting the vector from the player to the AI
		vectorTargetToSource = Vector3.Normalize(vectorTargetToSource);
		//getting the dot product
		float fDotProduct = Vector3.Dot (vectorTargetToSource, _source.transform.forward);
		
		//larger the dot product, smaller the view angle
		if (fDotProduct >= 0.55)	{
			
			RaycastHit playerHit;
			//test if the object hit is the player
			Physics.Linecast(_source.transform.position, _target.transform.position, out playerHit);
			
			if (playerHit.collider != null && playerHit.collider.gameObject.tag == "Player" 
				&& Vector3.Distance (_source.transform.position, _target.transform.position) < fViewDist) {
				//if player is sighted return a true
				return true;
			}
		}
		
		return false;
		
	}
	
	/*void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine (AI.transform.position, );
	} */
}
