﻿using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {


	struct circleEqu{
		public float radius;
		public Vector2 origin;
		public float getX(float z){
			//from : (x - a)^2 + (y - b)^2 = r^2 (2d circle equation)
			//       ________________
			// x = -/r^2 - (y - b)^2  + a

			return Mathf.Sqrt(radius*radius - ((z - origin.y)*(z - origin.y)) ) + origin.x;
		}

		public float getZ(float x){

			//from : (x - a)^2 + (y - b)^2 = r^2 (2d circle equation)
			//       ________________
			// y = -/r^2 - (x - a)^2  + b
			return Mathf.Sqrt(radius*radius - ((x - origin.x)*(x - origin.x)) ) + origin.y;
		}
	}

	public float height;
	public float radius;
	public float rotationSpeed;
	//public Vector3 target;
	public Transform target;
	private Camera cam;

	private circleEqu circle;




	private float angle;
	private float hyp;

	// Use this for initialization
	void Start () {


		cam = this.gameObject.GetComponent<Camera>();
		height = 200;
		radius = 400;

		//setting up the circle equation
		circle.radius = radius;
		circle.origin = new Vector2(target.position.x, target.position.z);
		float z = circle.getZ(circle.origin.x+radius);
		transform.position = new Vector3(circle.getX(z),height,z);

		//transform.position = new Vector3(cam.transform.position.x, height ,cam.transform.position.z);
		rotationSpeed = 0.01f;
		hyp = Mathf.Sqrt((height*height) + (radius * radius));
		angle = Mathf.Asin(radius/hyp);

		transform.Rotate(angle*(180/Mathf.PI),0,0);
		cam.farClipPlane = Vector3.Distance(target.transform.position, transform.position) + 100;



	}


	public void moveCamera(){
		float distance = Vector3.Distance(target.transform.position, transform.position);
		while (distance < radius){
			transform.position = new Vector3(transform.position.x+1,transform.position.y,transform.position.z+1);
			distance = Vector3.Distance(target.transform.position, transform.position);
		}
		while (distance > radius){
			transform.position = new Vector3(transform.position.x-10,transform.position.y,transform.position.z-10);
			distance = Vector3.Distance(target.transform.position, transform.position);
		}
	}

	public void rotateCamera(){
		float sinShift = Mathf.Sin(rotationSpeed);
		float cosShift = Mathf.Cos(rotationSpeed);

		//we back up the position of the target
		float targetX = target.transform.position.x;
		float targetZ = target.transform.position.z;

		//we calcualte the position of the camera if it where translated to the origin by subtracting the position of our target
		float pX = this.transform.position.x - targetX;
		float pZ = this.transform.position.z - targetZ;

		//we calculate the new positions based in our cos/sin shifts
		float posX = pX * cosShift - pZ * sinShift;
		float posZ = pX * sinShift + pZ * cosShift;

		//we assign the new position
		transform.position = new Vector3(posX + targetX,transform.position.y, posZ + targetZ );
	}




	// Update is called once per frame
	void Update () {
		circle.origin = new Vector2(target.position.x, target.position.z);
		//moveCamera();
		rotateCamera();
		transform.LookAt(target.transform.position);

	}




	public void recalibrateCamera(){
		//setting up the circle equation
		circle.radius = radius;
		circle.origin = new Vector2(target.position.x, target.position.z);
		float z = circle.getZ(circle.origin.x+radius);
		transform.position = new Vector3(circle.getX(z),height,z);
	
		hyp = Mathf.Sqrt((height*height) + (radius * radius));
		angle = Mathf.Asin(radius/hyp);
		transform.Rotate(angle*(180/Mathf.PI),0,0);
		cam.farClipPlane = Vector3.Distance(target.transform.position, transform.position) + 100;

	}

	public void setValues(float _height, float _radius){
		setHeight(_height);
		setRadius(_radius);
	}

	public void setHeight(float _height){
		this.height = _height;
		recalibrateCamera();
	}

	public void setRadius(float _radius){
		this.radius = _radius;
		recalibrateCamera();
	}


}
