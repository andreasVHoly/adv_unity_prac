using UnityEngine;
using System.Collections;

public class InterpolateChaseCam : MonoBehaviour {

	//the player, target we are following
	public Transform target;


	//own
	public float height;
	public float distance;



	public float t;

	void Start() {
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
