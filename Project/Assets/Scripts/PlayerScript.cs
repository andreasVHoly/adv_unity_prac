using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	private CharacterController controller;
	public Vector3 speed;
	public Vector3 move;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
		if (speed == null){
			speed = new Vector3(10,4,10);
		}
		move = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");
		move = new Vector3(0,0,0);

		if (inputX > 0){
			move = new Vector3(speed.x,move.y,move.z);
			print("pos x");
		}
		else if (inputX < 0){
			move = new Vector3(-speed.x,move.y,move.z);
			print("neg x");
		}

		if (inputZ > 0){
			move = new Vector3(move.x,move.y,speed.z);
			print("pos y");
		}
		else if (inputZ < 0){
			move = new Vector3(move.x,move.y,-speed.z);
			print("neg y");
		}

		controller.Move(move);


	}
}
