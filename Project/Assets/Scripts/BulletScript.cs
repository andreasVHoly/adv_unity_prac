using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


	public float speed;

	public float TTL;


	
	// Update is called once per frame
	void Update () {

		Destroy(gameObject,TTL);
	}

	void onCollisionEnter(Collision collision){
		print ("collided with " + collision.gameObject.name);
	}
}
