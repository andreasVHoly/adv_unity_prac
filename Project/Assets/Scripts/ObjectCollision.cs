using UnityEngine;
using System.Collections;

public class ObjectCollision : MonoBehaviour {


	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit){
		Rigidbody rbody = hit.collider.attachedRigidbody;

		if( rbody != null && !rbody.isKinematic && hit.moveDirection.y > -0.3f ){
			rbody.velocity = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z)*4;
			//Vector3 direction = rbody.transform.position - gameObject.transform.position;
			//rbody.AddForceAtPosition(direction.normalized, transform.position);
		}


	}

}
