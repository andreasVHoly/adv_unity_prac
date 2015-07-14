using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {

	public GameObject muzzleFlash;

	//the animator to handle the animations for the player
	private Animator animator;
	public Transform textObj;

	public Transform bullet;
	private Transform hitObject;
	public Transform bulletSpawn;

	public float bulletSpeed;

	public int damage;
	private Transform cam;

	private float reloadTime;
	private float reload;
	private bool reloading;

	private float shooting;
	private bool shot;

	// Use this for initialization
	void Start () {
		hitObject = null;
		cam = this.gameObject.GetComponent<PlayerScript>().fpsCam.transform;
		//we get the animator component
		animator = gameObject.GetComponent<Animator>();
		reloading = false;
		reloadTime = 3.08f;
		reload = 0;
		shooting = 0;
		shot = false;
	}
	
	// Update is called once per frame
	void Update () {
		reload += Time.deltaTime;
		shooting += Time.deltaTime;

		if (shooting > 0.3 && shot){
			shooting = 0;
			animator.SetBool("Shooting",false);
			shot = false;
		}

		if (reload > reloadTime){
			reloading = false;
			animator.SetBool("Reloading",reloading);
			reload =  0;
		}

		if (Input.GetButtonDown("Fire1") && !reloading){
			shootWeapon();
			animator.SetBool("Shooting",true);
			shot = true;

		}

		if (Input.GetKeyDown(KeyCode.R) && !reloading){
			reloading = true;
			animator.SetBool("Reloading",reloading);
		}
	}


	void shootWeapon(){





		//particle effect/muzzle flash
		var effect = Instantiate(muzzleFlash) as GameObject;
		effect.transform.position = bulletSpawn.position;
		effect.transform.rotation = bulletSpawn.rotation;
		Destroy(effect,0.5f);


		//ray casting and handling
		Ray shot = new Ray(cam.position,cam.forward);
		findShotObject(shot);
		//print(hitObject);
		if (hitObject != null){
			HealthScript health = hitObject.GetComponent<HealthScript>();

			if (health != null){health.takeDamage(damage);}

			var text = textObj.gameObject.GetComponentInChildren<Text>();
			text.text = hitObject.name;

		}

		//bullet instantiation

		Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
	
		//var bulletObj = Instantiate(bullet) as Transform;
		//bulletObj.transform.position = bulletSpawn.transform.position;
		//bulletObj.transform.rotation = gameObject.transform.rotation;
		//bulletObj.transform.LookAt(hitObject.position);
		//bulletObj.rigidbody.AddForce(gameObject.transform.forward * bulletSpeed);


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
