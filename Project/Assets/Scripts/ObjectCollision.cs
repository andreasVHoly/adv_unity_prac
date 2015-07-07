using UnityEngine;
using System.Collections;

public class ObjectCollision : MonoBehaviour {


	public float force;


	void OnControllerColliderHit(ControllerColliderHit hit){
		Rigidbody rbody = hit.collider.attachedRigidbody;

		if( rbody != null && 
		   !rbody.isKinematic && 
		   hit.moveDirection.y > -0.3f ){


			rbody.velocity = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z) * force;
			//Vector3 direction = rbody.transform.position - gameObject.transform.position;
			//rbody.AddForceAtPosition(direction.normalized, transform.position);
		}


	}

}
