using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//the speed tthe bullet will be moving at
	public float speed;

	//how long the bullet lives after being shot (Time To Live)
	public float TTL;


	void Start(){
		//we set the object to be destroyed after TTL s
		Destroy(gameObject,TTL);
	}


	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward*speed*Time.deltaTime);//we move the bullet with its transform
	}

}
