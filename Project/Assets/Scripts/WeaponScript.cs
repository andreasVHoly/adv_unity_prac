using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {
	//particle effect
	public GameObject muzzleFlash;

	//to get the sound manager
	public GameObject scripts;
	private SoundManager soundManager;

	//the animator to handle the animations for the player
	private Animator animator;


	public Transform bullet;
	//the object the ray cast hits
	private Transform hitObject;
	//where we spawn the bullet
	public Transform bulletSpawn;
	//public float bulletSpeed;

	public int damage;
	private Transform cam;

	private float reloadTime;
	private float reload;
	private bool reloading;

	private float shooting;
	private bool shot;

	private RaycastHit hitLocation;

	// Use this for initialization
	void Start () {
		soundManager = scripts.GetComponent<SoundManager>();
		hitObject = null;
		cam = this.gameObject.GetComponent<PlayerScript>().fpsCam.transform;
		//we get the animator component
		animator = gameObject.GetComponent<Animator>();
		//timers and bools to time the reloading animation
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

		//timing and managing the relaoding animation
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


		//shooting
		if (Input.GetButtonDown("Fire1") && !reloading){
			shootWeapon();
			animator.SetBool("Shooting",true);
			shot = true;

		}
		//reloading
		if (Input.GetKeyDown(KeyCode.R) && !reloading){
			reload = 0;
			reloading = true;
			animator.SetBool("Reloading",reloading);
		}
	}


	void shootWeapon(){
		//sound
		soundManager.playGunShot();

		//ray casting and handling
		Ray shot = new Ray(cam.position,cam.forward);
		findShotObject(shot);
		if (hitObject != null){
			//if we hit something we see if it has a health script to reduce its health
			HealthScript health = hitObject.GetComponent<HealthScript>();
			if (health != null){
				health.takeDamage(damage);
			}
		}


		//particle effect/muzzle flash
		var effect = Instantiate(muzzleFlash) as GameObject;
		effect.transform.position = bulletSpawn.position;
		effect.transform.LookAt(hitLocation.point);
		Destroy(effect,0.5f);

		//bullet instantiation
		bulletSpawn.LookAt(hitLocation.point);
		Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
	
	}


	//finds the closest object hit by the raycast
	void findShotObject(Ray raycast){
		hitObject = null;
		//all the objects hit by the raycast
		RaycastHit[] objects =  Physics.RaycastAll(raycast);
		int size = objects.Length;

		float lastDistance = 0;
		//we loop over all the objects
		for (int i = 0; i <size; i++){
			//we loop through and assign the closest object
			if (objects[i].transform != this.transform && (hitObject == null || objects[i].distance < lastDistance)){
				hitObject = objects[i].transform;
				lastDistance = objects[i].distance;
				hitLocation = objects[i];
			}
		}

	}

}
