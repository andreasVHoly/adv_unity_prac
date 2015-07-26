using UnityEngine;
using System.Collections;

public class CameraCycle : MonoBehaviour {
	

	//which camera we are currently on
	public int counter;
	//counter values
	//0 - orbit
	//1 - chase
	//2 - fps

	//the croisshair GUI Object, so we can disable it
	public GameObject crosshair;
	//all cameras
	public Camera [] cams;
	//UI objects for the cameras
	public GameObject orbitCamUI;
	public GameObject chaseCamUI;
	


	// Use this for initialization
	void Start () {
		counter = 2;//start with the fps cam
	}

	//selects the next camera and sets all nessesary values
	public void next(){
		counter++;
		//ensures no out of bounds
		if (counter > 2){
			counter = 0;
		}

		//disable all cameras
		for (int i = 0; i < 2; i++){
			cams[i].enabled = false;
		}

		//special rules for each camera
		//orbit cam
		if (counter == 0){
			orbitCamUI.gameObject.SetActive(true);

		}else{
			orbitCamUI.gameObject.SetActive(false);
		}
		//chase cam
		if (counter == 1){
			chaseCamUI.gameObject.SetActive(true);
			
		}else{
			chaseCamUI.gameObject.SetActive(false);
		}
		//crosshair
		if (counter == 2){
			crosshair.gameObject.SetActive(true);
		}
		else{
			crosshair.gameObject.SetActive(false);
		}
		//enable the right camera again
		cams[counter].enabled = true;
	}



}
