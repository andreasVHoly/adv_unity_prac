using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrbitCamUI : MonoBehaviour {

	//need to be assigned

	public Text height;
	public Text radius;


	public InputField radiusInput;
	public InputField heightInput;


	private string defaultH = "Height: ";
	private string defaultR = "Radius: ";


	public Camera orbitCam;

	private OrbitCamera orbitScript;
	private InputField test;

	// Use this for initialization
	void Start () {
		//we deactivate the elements as we only want them to be active for input when required
		radiusInput.gameObject.SetActive(false);
		heightInput.gameObject.SetActive(false);

		//we find the script to alter values etc
		orbitScript = orbitCam.GetComponent<OrbitCamera>();
		//we set the UI up with the default values from the script
		height.text = defaultH + orbitScript.height.ToString();
		radius.text = defaultR + orbitScript.radius.ToString();
		height.transform.position = new Vector3(Screen.width/2, Screen.height - Screen.height/10 - 20, height.transform.position.z);
		radius.transform.position = new Vector3(Screen.width/2, Screen.height - Screen.height/10, radius.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//we update the UI labels each frame regardless of change
		height.text = defaultH + orbitScript.height.ToString();
		radius.text = defaultR + orbitScript.radius.ToString();
	}


	//updates the radius from an input
	public void updateRadius(){
		float result = 0f;
		//checks if the input is valid
		if (float.TryParse(radiusInput.text,out result)){
			orbitScript.setRadius(result);
		}


	}
	//updates the height from an input
	public void updateHeight(){
		float result = 0f;
		//checks if the input is valid
		if (float.TryParse(heightInput.text,out result)){
			orbitScript.setHeight(result);
		}
	}
}
