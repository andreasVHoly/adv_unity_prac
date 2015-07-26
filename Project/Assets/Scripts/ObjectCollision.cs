using UnityEngine;
using System.Collections;

public class ObjectCollision : MonoBehaviour {

	//force we apply to the object
	public float force;

	//so that we move moveable objects that we collide with
	void OnControllerColliderHit(ControllerColliderHit hit){
		Rigidbody rbody = hit.collider.attachedRigidbody;

		if( rbody != null && 
		   !rbody.isKinematic && 
		   hit.moveDirection.y > -0.3f ){


			rbody.velocity = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z) * force;
		}


	}

}
