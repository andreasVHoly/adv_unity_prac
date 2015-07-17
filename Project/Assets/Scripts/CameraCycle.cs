using UnityEngine;
using System.Collections;

public class CameraCycle : MonoBehaviour {
	

	
	public int counter;
	public GameObject crosshair;
	public Camera [] cams;

	public GameObject orbitCamUI;
	public GameObject chaseCamUI;
	
	//counter values
	//0 - orbit
	//1 - chase
	//2 - fps


	// Use this for initialization
	void Start () {
		counter = 2;
	}


	public void next(){
		counter++;
		if (counter > 2){
			counter = 0;
		}
		for (int i = 0; i < 2; i++){
			cams[i].enabled = false;
		}
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
		cams[counter].enabled = true;
	}
	
	public void previous(){
		counter--;
		if (counter < 0){
			counter = 2;
		}
		for (int i = 0; i < 2; i++){
			cams[i].enabled = false;
		}
		if (counter != 2){
			crosshair.gameObject.SetActive(false);
		}

		cams[counter].enabled = true;
	}
}
