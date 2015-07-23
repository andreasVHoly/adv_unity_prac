using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour {


	private SoundManager soundManager;

	private CameraCycle camCycle;

	private OrbitCamUI orbitCamUI;
	private ChaseCamUI chaseCamUI;

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
		if (Input.GetKeyDown(KeyCode.C)){
			camCycle.next();
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}


		//orbit camera input
		if (Input.GetKeyDown(KeyCode.Alpha1) && camCycle.counter == 0 && !orbitListen2){
			orbitCamUI.radiusInput.gameObject.SetActive(true);
			orbitCamUI.radiusInput.ActivateInputField();
			orbitListen1 = true;
			soundManager.playUISound();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2) && camCycle.counter == 0 && !orbitListen1){
			orbitCamUI.heightInput.gameObject.SetActive(true);
			orbitCamUI.heightInput.ActivateInputField();
			orbitListen2 = true;
			soundManager.playUISound();
		}


		//chase camera input
		if (Input.GetKeyDown(KeyCode.Alpha1) && camCycle.counter == 1 && !chaseListen2){
			chaseCamUI.distanceInput.gameObject.SetActive(true);
			chaseCamUI.distanceInput.ActivateInputField();
			chaseListen1 = true;
			soundManager.playUISound();
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2) && camCycle.counter == 1 && !chaseListen1){
			chaseCamUI.heightInput.gameObject.SetActive(true);
			chaseCamUI.heightInput.ActivateInputField();
			chaseListen2 = true;
			soundManager.playUISound();
		}



	}

	void OnGUI(){
		Event keycheck = Event.current;
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
