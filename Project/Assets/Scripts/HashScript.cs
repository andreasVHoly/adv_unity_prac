using UnityEngine;
using System.Collections;

public class HashScript : MonoBehaviour {

	public int emptyState;
	public int walkState;
	public int walkFastState;
	public int fallBackState;
	public int attackState;

	public int deadBool;
	public int attackBool;
	public int speedFloat;


	void Awake(){
		emptyState = Animator.StringToHash("Base Layer.New State");
		walkState = Animator.StringToHash("Base Layer.Walk");
		walkFastState = Animator.StringToHash("Base Layer.WalkFast");
		fallBackState = Animator.StringToHash("Base Layer.FallBack");
		attackState = Animator.StringToHash("Base Layer.Attack");

		deadBool = Animator.StringToHash("Dead");
		attackBool = Animator.StringToHash("Attack");
		speedFloat = Animator.StringToHash("Speed");
	}

}
