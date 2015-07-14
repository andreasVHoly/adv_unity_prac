using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


	public float speed;

	public float TTL;


	void Start(){
		Destroy(gameObject,TTL);
	}
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward*speed*Time.deltaTime);

	}

	void onCollisionEnter(Collision collision){
		print ("collided with " + collision.gameObject.name);
	}
}
