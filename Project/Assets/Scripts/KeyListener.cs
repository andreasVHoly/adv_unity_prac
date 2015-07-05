using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour {


	public CameraCycle camCycle;
	
	

	
	
	// Use this for initialization
	void Start () {
		camCycle = gameObject.GetComponent<CameraCycle>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C)){
			camCycle.next();
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
	
	


}
