using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {


	public float height;
	public float radius;
	public float rotationSpeed;
	//public Vector3 target;
	public Transform target;
	private Camera cam;


	private float angle;
	private float hyp;

	// Use this for initialization
	void Start () {
		cam = this.gameObject.GetComponent<Camera>();
		height = 200;
		radius = 100;
		transform.position = new Vector3(cam.transform.position.x, height ,cam.transform.position.z);
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
		//moveCamera();
		rotateCamera();
		transform.LookAt(target.transform.position);

	}




	public void recalibrateCamera(){
		cam.transform.position = new Vector3(cam.transform.position.x, height ,cam.transform.position.z);
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
