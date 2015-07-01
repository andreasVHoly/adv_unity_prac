using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	private CharacterController controller;
	public Vector3 speed;
	public Vector3 move;


	public Animator animator;

	//tut
	public float smoothing = 15f;
	public float damping = 0.1f;


	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		controller = gameObject.GetComponent<CharacterController>();
		if (speed == null){
			speed = new Vector3(10,4,10);
		}
		move = new Vector3(0,0,0);
	}


	void FixedUpdate(){
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");


		move = new Vector3(inputX,0,inputZ);

		
		if (inputX != 0 || inputZ != 0){

			Quaternion direction = Quaternion.LookRotation(move,Vector3.up);
			
			Quaternion rotation = Quaternion.Lerp(rigidbody.rotation, direction, smoothing*Time.deltaTime);
			rigidbody.MoveRotation(rotation);
			controller.Move(move);
		}



	}



}
