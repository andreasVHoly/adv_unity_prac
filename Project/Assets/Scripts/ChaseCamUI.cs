using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChaseCamUI : MonoBehaviour {

	//need to be assigned
	
	public Text height;
	public Text distance;

	//input fields
	public InputField distanceInput;
	public InputField heightInput;
	
	//default display
	private string defaultH = "Height: ";
	private string defaultR = "Distance: ";

	//camera we are working with
	public Camera chaseCam;
	//cameras script
	private ChaseCam chaseScript;

	
	// Use this for initialization
	void Start () {
		//we deactivate the elements as we only want them to be active for input when required
		distanceInput.gameObject.SetActive(false);
		heightInput.gameObject.SetActive(false);
		
		//we find the script to alter values etc
		chaseScript = chaseCam.GetComponent<ChaseCam>();
		//we set the UI up with the default values from the script
		height.text = defaultH + chaseScript.height.ToString();
		distance.text = defaultR + chaseScript.distance.ToString();
		height.transform.position = new Vector3(Screen.width/2, Screen.height - Screen.height/10 - 20, height.transform.position.z);
		distance.transform.position = new Vector3(Screen.width/2, Screen.height - Screen.height/10, distance.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//we update the UI labels each frame regardless of change
		height.text = defaultH + chaseScript.height.ToString();
		distance.text = defaultR + chaseScript.distance.ToString();
	}
	
	
	//updates the radius from an input
	public void updateDistance(){
		float result = 0f;
		//checks if the input is valid
		if (float.TryParse(distanceInput.text,out result)){
			chaseScript.setDistance(result);
		}
		
		
	}
	//updates the height from an input
	public void updateHeight(){
		float result = 0f;
		//checks if the input is valid
		if (float.TryParse(heightInput.text,out result)){
			chaseScript.setHeight(result);
		}
	}
}
