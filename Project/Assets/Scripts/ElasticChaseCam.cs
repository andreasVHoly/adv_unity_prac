using UnityEngine;
using System.Collections;

public class ElasticChaseCam : MonoBehaviour {

	//the player, target we are following
	public Transform target;


	//redo
	
	public float force;
	public float stiffness;
	public float distance;
	public float mass;
	public float acceleration;
	public float damping;

	//formulas
	// F (force) = d (distance) x s (spring stiffness)
	// F (force) = m (mass) x a (acceleration)



	void Start(){
		force = stiffness*distance;
		acceleration = force/mass;
	}

	void Update(){

	}

	//used here so that the players position has been updated before we update the cameras position
	void LateUpdate(){

	}






}
