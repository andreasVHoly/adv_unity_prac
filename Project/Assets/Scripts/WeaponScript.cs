using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {



	public Transform textObj;

	public Transform bullet;
	private Transform hitObject;
	public Transform bulletSpawn;

	public float bulletSpeed;

	public int damage;
	private Transform cam;

	// Use this for initialization
	void Start () {
		hitObject = null;
		cam = this.gameObject.GetComponent<PlayerScript>().fpsCam.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
			shootWeapon();
		}
	}


	void shootWeapon(){




		//print(cam);
		Ray shot = new Ray(cam.position,cam.forward);

		findShotObject(shot);
		print(hitObject);
		if (hitObject != null){
			HealthScript health = hitObject.GetComponent<HealthScript>();

			if (health != null){health.takeDamage(damage);}

			var text = textObj.gameObject.GetComponentInChildren<Text>();
			text.text = hitObject.name;

		}

		/*var bulletObj = Instantiate(bullet) as Transform;
		bulletObj.transform.position = bulletSpawn.transform.position;
		bulletObj.transform.rotation = gameObject.transform.rotation;
		bulletObj.transform.LookAt(hitObject.position);
		bulletObj.rigidbody.AddForce(gameObject.transform.forward * bulletSpeed);*/
		/*Debug.DrawLine (gameObject.transform.position, hitObject.transform.position);
		var bulletObj = Instantiate(bullet, bulletSpawn.transform.position, gameObject.transform.rotation) as Transform;
		bulletObj.transform.LookAt(hitObject.transform.position);
		bulletObj.rigidbody.AddForce(gameObject.transform.forward * bulletSpeed);*/
	}

	void findShotObject(Ray raycast){
		hitObject = null;
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
