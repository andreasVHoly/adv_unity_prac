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
		rotationSpeed = 0.01f;
		hyp = Mathf.Sqrt((height*height) + (radius * radius));
		angle = Mathf.Asin(radius/hyp);
		print ("height " + height);
		print ("hypotenuse " + hyp);
		print ("radius " + radius);
		print ("angle in r " + angle);
		print ("angle in d " + angle*(180/Mathf.PI));
		print ("new angle " + (angle*(180/Mathf.PI)+90));

		transform.Rotate(angle*(180/Mathf.PI),0,0);
		cam.farClipPlane = Vector3.Distance(target.transform.position, transform.position) + 100;
		//transform.Rotate(angle,0,0, Space.Self);
		//transform.Rotate(angle,0,0, Space.World);
		//target = new Vector3(-149.0f, 0.63f, -2.56f);
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
		//transform.position = target.position + (transform.position - target.position).normalized * radius;
		if (target != null){
			//transform.position = new Vector3(target.position.x + radius, target.position.y + height, target.position.z + radius);
			//transform.rotation.x = angle;
			//transform.Rotate(0,rotationSpeed * Time.deltaTime,0, Space.World);
			//transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
			rotateCamera();
			transform.LookAt(target.transform.position);
		}
		else{
			print ("Please assign target first!");
		}
	}
}
