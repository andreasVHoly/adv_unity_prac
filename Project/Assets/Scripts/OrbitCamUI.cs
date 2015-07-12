using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrbitCamUI : MonoBehaviour {

	//need to be assigned

	public Text height;




	public InputField radiusInput;
	public InputField heightInput;


	private string defaultH = "Height: ";
	private string defaultR = "Radius: ";
	public Text radius;

	public Camera orbitCam;

	private OrbitCamera orbitScript;
	private InputField test;

	// Use this for initialization
	void Start () {
		radiusInput.gameObject.SetActive(false);
		heightInput.gameObject.SetActive(false);


		orbitScript = orbitCam.GetComponent<OrbitCamera>();
		height.text = defaultH + orbitScript.height.ToString();
		radius.text = defaultR + orbitScript.radius.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		height.text = defaultH + orbitScript.height.ToString();
		radius.text = defaultR + orbitScript.radius.ToString();
	}


	public void updateRadius(){
		float result = 0f;
		if (float.TryParse(radiusInput.text,out result)){
			orbitScript.setRadius(result);
		}


	}
	public void updateHeight(){
		float result = 0f;
		if (float.TryParse(heightInput.text,out result)){
			orbitScript.setHeight(result);
		}
	}
}
