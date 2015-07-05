using UnityEngine;
using System.Collections;

public class RandomObjectCreation : MonoBehaviour {


	public Material[] materials;




	// Use this for initialization
	void Start () {
		int value = Random.Range(0,5);
		//int value = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
