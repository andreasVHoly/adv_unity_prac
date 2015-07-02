﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	public Camera fpsCam;


	//the controller that we use to move the player
	private CharacterController controller;
	//the speed of the character
	public Vector3 charSpeed;
	//the speed at which the mouse rotates
	public Vector3 mouseSpeed;
	//a vector we use to move the player
	private Vector3 move;

	//the animator to handle the animations for the player
	private Animator animator;

	private HashScript hash;
	//float value for the rotation on the vertical axis
	private float rotationValueY;
	private float rotationValueX;

	//float for the jumping velocity calculations
	private float jumpingVelocity;

	//tut
	public float smoothing = 15f;
	public float damping = 0.1f;


	// Use this for initialization
	void Start () {
		//we set up the movement speed to be equal on the x,z and y is the jumping speed
		charSpeed = new Vector3(7f,5f,7f);
		//we set the mouse speed
		mouseSpeed = new Vector3(3f,3f,3f);
		hash = gameObject.GetComponent<HashScript>();
		//this allows the mouse to go off the screen
		Screen.lockCursor = true;

		//we get the animator component
		animator = gameObject.GetComponent<Animator>();
		//we get the character controller component
		controller = gameObject.GetComponent<CharacterController>();
		//default
		move = new Vector3(0,0,0);
		rotationValueY = 0f;
		rotationValueX = 0f;
	}




	void rotatePlayer(float mouseX, float mouseY){
		//we rotate on the horzontal axis
		transform.Rotate(0,mouseX,0);

		//fpsCam.transform.Rotate(0,mouseX,0);
		//we rotate on the vertical axis


		rotationValueY -= mouseY;
		rotationValueY = Mathf.Clamp(rotationValueY, -90f, 90f);


		fpsCam.transform.localRotation = Quaternion.Euler(rotationValueY,0,0);
	}

	void movePlayer(float moveX, float moveZ){
		//we check if the player is trying to jump while on the floor, check for button press first as this will allow less checks on for the grounded flag
		if(Input.GetButtonDown("Jump") && controller.isGrounded){
			jumpingVelocity = charSpeed.y;
		}
		//we calculate in the gravity for the jump
		jumpingVelocity += Physics.gravity.y * Time.deltaTime;
		
		//we calcuate the amount we move by the speed
		float speedX = moveX * charSpeed.x;
		float speedZ = moveZ * charSpeed.z;
		
		//we make our new vextor with all 3d velocities added
		move = new Vector3(speedX,jumpingVelocity,speedZ);
		
		//we factor in the rotation
		move = transform.rotation * move;
	}

	void Update(){
		//we get the key movement of the player on the hor and ver axis
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");
		//we get the mouse movement of the player
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		//we calculate the rotation for the mouse movement
		float rotationX = mouseX * mouseSpeed.x;
		float rotationY = mouseY * mouseSpeed.y;
		//send through the values to rotate
		rotatePlayer(rotationX,rotationY);

		//we send through the data to move the player
		movePlayer(moveX,moveZ);


		//we now send this information through to the character controller
		controller.Move(move * Time.deltaTime);

		//animator.SetFloat(hash.speedFloat, 5, damping, Time.deltaTime);
		//animator.Play(hash.walkState);
		//animator.Play("Walk");
		animator.Play("Base Layer.test");
		/*move = new Vector3(inputX,0,inputZ);

		
		if (inputX != 0 || inputZ != 0){

			Quaternion direction = Quaternion.LookRotation(move,Vector3.up);
			
			Quaternion rotation = Quaternion.Lerp(rigidbody.rotation, direction, smoothing*Time.deltaTime);
			rigidbody.MoveRotation(rotation);
			controller.Move(move);
		}*/



	}



}
