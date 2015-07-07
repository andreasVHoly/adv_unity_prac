using UnityEngine;
using System.Collections;

public class RandomObjectCreation : MonoBehaviour {

	//needs to be assigned in unity
	public Material[] materials;
	//needs to be assigned in unity
	public Transform[] objects;

	public Vector3 maxBound = new Vector3(439,10,470);

	public Vector3 minBound = new Vector3(-151,1,-183);

	public Vector3 position;

	public int amount;




	// Use this for initialization
	void Start () {

		if (amount == 0){
			amount = 10;
		}



	}


	Vector3 getPosition(){
		return new Vector3(Random.Range(minBound.x,maxBound.x),
		                   Random.Range(minBound.y,maxBound.y),
		                   Random.Range(minBound.z,maxBound.z));
	}


	void spawnItems(int no){
		int arraySize = objects.Length;

		//var bulletObj = Instantiate(bullet, bulletSpawn.transform.position, gameObject.transform.rotation) as Transform;
		for (int i = 0; i < no; i++){
			var obj = Instantiate(objects[Random.Range(0,arraySize)], getPosition(), new Quaternion(0,0,0,1)) as Transform;
			//obj.
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
