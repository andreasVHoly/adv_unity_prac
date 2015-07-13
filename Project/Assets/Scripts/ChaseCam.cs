using UnityEngine;
using System.Collections;

public class ChaseCam : MonoBehaviour {

	//the player, target we are following
	public Transform target;

	//the speed we start with
	public float initialSpeed;
	//max speed
	public float maxSpeed;
	//the acceleration
	public float acceleration;
	//speed we are currently travelling at
	public float speed;




	//the distance away from the target when standing still
	private float distance;
	private float dMax;
	private float dMin;
	public float dRest;



	public float height;

	


	// Use this for initialization
	void Start () {
		distance = 0;
		dMax = dRest+15;
		dMin = dRest+10;
		transform.position = new Vector3(target.position.x, height, target.position.z-dRest);
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(transform.position,target.position);
		/*if (speed > initialSpeed && dist < distance){
			speed -= acceleration;
		}
		if (speed < maxSpeed && dist < distance){
			speed += acceleration;
		}*/


		if (distance > dMax){
			//speed = initialSpeed;
		}
		if (distance >= dMin){
			speed += acceleration;
		}

		if (distance <= dMin && speed > 0){
			speed -= acceleration;
		}

		if (distance <= dRest){
			//speed = 0;
		}



		//transform.position = new Vector3(target.position.x, height, target.position.z-distance);
		transform.Translate(target.forward*speed);
		//controller.Move(speed * Time.deltaTime);


	}





	/*public void setValues(float _height, float _radius){
		setHeight(_height);
		setRadius(_radius);
	}
	
	public void setHeight(float _radius){
		this.radius = _radius;
	}
	
	public void setRadius(float _radius){
		this.radius = _radius;
	}*/


}
