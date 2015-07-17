using UnityEngine;
using System.Collections;

public class LerpChaseCam : MonoBehaviour {

	//the player, target we are following
	public Transform target;


	//own
	public float height;
	public float distance;

		//unity
	public float movementSpeed;
	
	public float followSpeed;



	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	void Start() {
		startTime = Time.time;
		journeyLength = Vector3.Distance(transform.position, target.position);
	}
	void LateUpdate() {
		float dist = Vector3.Distance(transform.position,target.position);

		if (dist > distance){
			print("moving");
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			Vector3 newCamPos = new Vector3(target.position.x, target.position.y+height, target.position.z - (distance*2));
			Vector3 newTargetPos = new Vector3(target.position.x, target.position.y+height, target.position.z );
			transform.position = Vector3.Lerp(newCamPos, newTargetPos, fracJourney);
		}

	}


	/*void Start(){

	}

	void Update(){

	}

	//used here so that the players position has been updated before we update the cameras position
	void LateUpdate(){

	}*/






}
