﻿using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {


	public float initialSpeed;
	public float maxSpeed;

	public Transform target;

	public float deltaSpeed;
	public float speed;

	private CharacterController controller;


	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (speed > initialSpeed){
			speed -= deltaSpeed;
		}
		//controller.Move(speed * Time.deltaTime);


	}


	void speedUp(){
		if (speed < maxSpeed && speed > initialSpeed){
			speed += deltaSpeed;
		}
		//controller.Move(speed * Time.deltaTime);

	}


}
