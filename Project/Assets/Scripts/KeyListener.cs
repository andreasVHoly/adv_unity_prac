using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyListener : MonoBehaviour {


	private SoundManager soundManager;

	private CameraCycle camCycle;

	private OrbitCamUI orbitCamUI;
	private ChaseCamUI chaseCamUI;

	//for camera UI
	private bool orbitListen1, orbitListen2, chaseListen1, chaseListen2;
	

	
	
	// Use this for initialization
	void Start () {
		camCycle = gameObject.GetComponent<CameraCycle>();
		orbitCamUI = gameObject.GetComponent<OrbitCamUI>();
		chaseCamUI = gameObject.GetComponent<ChaseCamUI>();
		orbitListen1 = false;
		orbitListen2 = false;
		chaseListen1 = false;
		chaseListen2 = false;
		soundManager = gameObject.GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//to cycle the cameras
		if (Input.GetKeyDown(KeyCode.C)){
			camCycle.next();
		}
		//to exit the game
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}


		//orbit camera input for radius
		if (Input.GetKeyDown(KeyCode.Alpha1) && camCycle.counter == 0 && !orbitListen2){
			//activate the input field
			activateField(orbitCamUI.radiusInput);
			orbitListen1 = true;
		}
		//orbit camera input for height
		if (Input.GetKeyDown(KeyCode.Alpha2) && camCycle.counter == 0 && !orbitListen1){
			//activate the input field
			activateField(orbitCamUI.heightInput);
			orbitListen2 = true;
		}


		//chase camera input for distance
		if (Input.GetKeyDown(KeyCode.Alpha1) && camCycle.counter == 1 && !chaseListen2){
			//activate the input field
			activateField(chaseCamUI.distanceInput);
			chaseListen1 = true;
		}
		//chase camera input for height
		if (Input.GetKeyDown(KeyCode.Alpha2) && camCycle.counter == 1 && !chaseListen1){
			//activate the input field
			activateField(chaseCamUI.heightInput);
			chaseListen2 = true;
		}



	}


	void activateField(InputField input){
		input.gameObject.SetActive(true);
		input.ActivateInputField();
		//play the UI sound
		soundManager.playUISound();
	}


	void OnGUI(){
		//to get the event of pressing enter
		//can only be captured in the ongui function
		Event keycheck = Event.current;

		//after we get input we update the camera values and hide the input fields again
		//chase camera
		if (chaseListen1 && keycheck.keyCode == KeyCode.Return){

			chaseCamUI.updateDistance();
			chaseCamUI.distanceInput.DeactivateInputField();
			chaseCamUI.distanceInput.gameObject.SetActive(false);
			chaseListen1 = false;
			
		}
		
		else if (chaseListen2 && keycheck.keyCode == KeyCode.Return){
			chaseCamUI.updateHeight();
			chaseCamUI.heightInput.DeactivateInputField();
			chaseCamUI.heightInput.gameObject.SetActive(false);
			chaseListen2 = false;
			
		}

		//orbit camera
		if (orbitListen1 && keycheck.keyCode == KeyCode.Return){
			orbitCamUI.updateRadius();
			orbitCamUI.radiusInput.DeactivateInputField();
			orbitCamUI.radiusInput.gameObject.SetActive(false);
			orbitListen1 = false;
			
		}

		else if (orbitListen2 && keycheck.keyCode == KeyCode.Return){
			orbitCamUI.updateHeight();
			orbitCamUI.heightInput.DeactivateInputField();
			orbitCamUI.heightInput.gameObject.SetActive(false);
			orbitListen2 = false;
			
		}
	}
	
	


}
