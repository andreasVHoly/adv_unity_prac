using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {




	private Transform hitObject;

	public int damage;


	// Use this for initialization
	void Start () {
		hitObject = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
			shootWeapon();
		}
	}


	void shootWeapon(){
		Transform cam = this.gameObject.GetComponent<PlayerScript>().fpsCam.transform;

		print(cam);
		Ray shot = new Ray(cam.position,cam.forward);

		findShotObject(shot);
		print(hitObject);
		if (hitObject != null){
			HealthScript health = hitObject.GetComponent<HealthScript>();
			if (health != null){health.takeDamage(damage);}

		}



	}

	void findShotObject(Ray raycast){
		RaycastHit[] objects =  Physics.RaycastAll(raycast);
		int size = objects.Length;

		float lastDistance = 0;

		for (int i = 0; i <size; i++){
			if (objects[i].transform != this.transform && (hitObject == null || objects[i].distance < lastDistance)){
				hitObject = objects[i].transform;
				lastDistance = objects[i].distance;
			}
		}

	}

}
