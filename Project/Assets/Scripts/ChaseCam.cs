using UnityEngine;
using System.Collections;

public class ChaseCam : MonoBehaviour {

	//the player, target we are following
	public Transform target;


	//values that can be set by the player
	public float height;
	public float distance;



	private float t;

	void Start() {
		t = 0.1f;
		//initial set up
		transform.position = new Vector3(target.position.x, height, target.position.z-distance);
	}


	void LateUpdate() {
		float dist = Vector3.Distance(transform.position,target.position);
		transform.LookAt(target.position);
		if (dist > distance){
			print("moving " + dist + " " + distance);

			Vector3 newPos = transform.position + t * Vector3.Normalize(target.position - transform.position);
			transform.position = new Vector3(newPos.x, height, newPos.z);
		}
	}







}
