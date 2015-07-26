using UnityEngine;
using System.Collections;

public class RandomObjectCreation : MonoBehaviour {

	//needs to be assigned in unity
	public Material[] materials;
	//needs to be assigned in unity
	public Transform[] objects;


	//clamps to confine the player to a smaller part of the map
	public float xMin, xMax, yMin, yMax, zMin, zMax;
	//amount of objects to spawn
	public int amount;
	//parent object they are spawned under
	public Transform parentObject;
	//position
	private Vector3 position;


	// Use this for initialization
	void Start () {
		if (amount == 0){
			amount = 40;
		}
		//clamp values
		xMin = -216;
		xMax = 5;
		yMin = 1;
		yMax = 10;
		zMin = -156;
		zMax = 203;
		spawnItems(amount);
	}

	//returns a new position within the defined range
	Vector3 getPosition(){
		return new Vector3(Random.Range(xMin,xMax), 
		                   Random.Range(yMin,yMax),
		                   Random.Range(zMin,zMax));
	}


	void spawnItems(int no){
		int arraySize = objects.Length;


		for (int i = 0; i < no; i++){
			//assign a random material
			int materialChoice = Random.Range(0, materials.Length);
			//assign a random shape
			int shapeChoice = Random.Range(0,arraySize);
			//instantiate this object at a random position
			var obj = Instantiate(objects[shapeChoice], getPosition(), new Quaternion(0,0,0,1)) as Transform;
			//set the parent
			obj.parent = parentObject;
			//set the material
			obj.GetChild(0).renderer.material = materials[materialChoice];
			//set a random health value
			obj.GetComponent<HealthScript>().health = Random.Range(20,80);
		}
	}


}
