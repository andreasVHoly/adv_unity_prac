using UnityEngine;
using System.Collections;

public class FPSCam : MonoBehaviour {


	public Transform target;
	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		if (target == null){
			print ("Please assign target first!");
			return;
		}

		targetPos = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = target.transform.position;
		transform.position = new Vector3(targetPos.x,transform.position.y,targetPos.z);
		//transform.rotation = target.transform.rotation;

	}
}
