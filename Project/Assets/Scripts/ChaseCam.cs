using UnityEngine;
using System.Collections;

public class ChaseCam : MonoBehaviour {

	//the player, target we are following
	public Transform target;
	//to update the clipping plane as we change values
	private Camera cam;

	//values that can be set by the player
	public float height;
	public float distance;

	//t value for the linear interpolation
	private float t;

	void Start() {
		t = 0.1f;
		//initial set up
		transform.position = new Vector3(target.position.x, height, target.position.z-distance);
		cam = gameObject.GetComponent<Camera>();
		//we change the clipping plane view
		cam.farClipPlane = Vector3.Distance(target.transform.position, transform.position) + 1000;
	}

	//called so that the player is updated before the cam
	void LateUpdate() {
		float dist = Vector3.Distance(transform.position,target.position);
		transform.LookAt(target.position);

		if (dist > distance){//if we should start following, (delay)
			//we get a new position from linear interpolation
			Vector3 newPos = transform.position + t * Vector3.Normalize(target.position - transform.position);
			transform.position = new Vector3(newPos.x, height, newPos.z);
		}
	}

	//recalculates all values for the camera once one of the values change
	public void recalibrateCamera(){
		transform.position = new Vector3(target.position.x, height, target.position.z-distance);
		cam.farClipPlane = Vector3.Distance(target.transform.position, transform.position) + 100;
	}

	//setters
	public void setValues(float _height, float _distance){
		setHeight(_height);
		setDistance(_distance);
	}
	
	public void setHeight(float _height){
		this.height = _height;
		recalibrateCamera();
	}
	
	public void setDistance(float _distance){
		this.distance = _distance;
		recalibrateCamera();
	}






}
