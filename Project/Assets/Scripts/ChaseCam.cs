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



	private float t;

	void Start() {
		t = 0.1f;
		//initial set up
		transform.position = new Vector3(target.position.x, height, target.position.z-distance);
		cam = gameObject.GetComponent<Camera>();
		cam.farClipPlane = Vector3.Distance(target.transform.position, transform.position) + 100;
	}


	void LateUpdate() {
		float dist = Vector3.Distance(transform.position,target.position);
		transform.LookAt(target.position);
		if (dist > distance){
			//print("moving " + dist + " " + distance);

			Vector3 newPos = transform.position + t * Vector3.Normalize(target.position - transform.position);
			transform.position = new Vector3(newPos.x, height, newPos.z);
		}
	}


	public void recalibrateCamera(){
		transform.position = new Vector3(target.position.x, height, target.position.z-distance);
		cam.farClipPlane = Vector3.Distance(target.transform.position, transform.position) + 100;
	}

	
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
