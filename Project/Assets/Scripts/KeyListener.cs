using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour {


	private CameraCycle camCycle;

	private OrbitCamUI camUI;

	private bool orbitListen1, orbitListen2;
	

	
	
	// Use this for initialization
	void Start () {
		camCycle = gameObject.GetComponent<CameraCycle>();
		camUI = gameObject.GetComponent<OrbitCamUI>();
		orbitListen1 = false;
		orbitListen2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C)){
			camCycle.next();
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		if (Input.GetKeyDown(KeyCode.Alpha1) && camCycle.counter == 0){
			camUI.radiusInput.gameObject.SetActive(true);
			camUI.radiusInput.ActivateInputField();
			orbitListen1 = true;

		}

		if (Input.GetKeyDown(KeyCode.Alpha2) && camCycle.counter == 0){
			camUI.heightInput.gameObject.SetActive(true);
			camUI.heightInput.ActivateInputField();
			orbitListen2 = true;
		}



	}

	void OnGUI(){
		Event keycheck = Event.current;
		if (orbitListen1 && keycheck.keyCode == KeyCode.Return){
			camUI.updateRadius();
			camUI.radiusInput.DeactivateInputField();
			camUI.radiusInput.gameObject.SetActive(false);
			orbitListen1 = false;
			
		}

		else if (orbitListen2 && keycheck.keyCode == KeyCode.Return){
			camUI.updateHeight();
			camUI.heightInput.DeactivateInputField();
			camUI.heightInput.gameObject.SetActive(false);
			orbitListen2 = false;
			
		}
	}
	
	


}
