using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {


	public float height;
	public float radius;
	public float rotationSpeed;
	//public Vector3 target;
	public Transform target;
	private Camera camera;


	private float angle;
	private float hyp;

	// Use this for initialization
	void Start () {
		camera = this.gameObject.GetComponent<Camera>();
		height = 200;
		radius = 100;
		rotationSpeed = 30;
		hyp = Mathf.Sqrt((height*height) + (radius * radius));
		angle = Mathf.Asin(radius/hyp);
		print ("height " + height);
		print ("hypotenuse " + hyp);
		print ("radius " + radius);
		print ("angle in r " + angle);
		print ("angle in d " + angle*(180/Mathf.PI));
		print ("new angle " + (angle*(180/Mathf.PI)+90));

		transform.Rotate(angle*(180/Mathf.PI),0,0);
		//transform.Rotate(angle,0,0, Space.Self);
		//transform.Rotate(angle,0,0, Space.World);
		//target = new Vector3(-149.0f, 0.63f, -2.56f);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = target.position + (transform.position - target.position).normalized * radius;
		if (target != null){
			transform.position = new Vector3(target.position.x + radius, target.position.y + height, target.position.z + radius);
			//transform.rotation.x = angle;
			//transform.Rotate(0,rotationSpeed * Time.deltaTime,0, Space.World);
			transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
		}
		else{
			print ("Please assign target first!");
		}
	}
}
