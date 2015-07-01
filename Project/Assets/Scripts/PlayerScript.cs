using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	private CharacterController controller;
	public Vector3 speed;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
		if (speed == null){
			speed = new Vector3(10,4,10);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Input.GetAxis
	}
}
