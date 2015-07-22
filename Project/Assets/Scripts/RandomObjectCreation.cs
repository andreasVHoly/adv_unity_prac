using UnityEngine;
using System.Collections;

public class RandomObjectCreation : MonoBehaviour {

	//needs to be assigned in unity
	public Material[] materials;
	//needs to be assigned in unity
	public Transform[] objects;






	public float xMin, xMax, yMin, yMax, zMin, zMax;

	public int amount;

	public Transform parentObject;

	private Vector3 position;


	// Use this for initialization
	void Start () {
		if (amount == 0){
			amount = 40;
		}
		xMin = -216;
		xMax = 5;
		yMin = 1;
		yMax = 10;
		zMin = -156;
		zMax = 203;
		spawnItems(amount);


	}


	Vector3 getPosition(){
		//float xPos = Random.Range(xMin,xMax);
		//float yPos = Random.Range(yMin,yMax);
		//float zPos = Random.Range(zMin,zMax);
		//print("spawning at " + xPos + " , " + yPos + " , " + zPos);
		return new Vector3(Random.Range(xMin,xMax), 
		                   Random.Range(yMin,yMax),
		                   Random.Range(zMin,zMax));
	}


	void spawnItems(int no){
		int arraySize = objects.Length;

		//var bulletObj = Instantiate(bullet, bulletSpawn.transform.position, gameObject.transform.rotation) as Transform;
		for (int i = 0; i < no; i++){
			int materialChoice = Random.Range(0, materials.Length);
			int shapeChoice = Random.Range(0,arraySize);

			var obj = Instantiate(objects[shapeChoice], getPosition(), new Quaternion(0,0,0,1)) as Transform;
			obj.parent = parentObject;
			obj.GetChild(0).renderer.material = materials[materialChoice];

			//print("adding " + objects[shapeChoice].name + " with material " + materials[materialChoice].name);
		}
	}


}
