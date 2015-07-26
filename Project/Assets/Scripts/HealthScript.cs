using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {


	//scripts object so we can access the sound manager
	public GameObject scripts;
	private SoundManager soundManager;

	//particle effects
	public GameObject smoke;
	public GameObject explosion;

	//health value
	public int health = 100;

	void Start(){
		soundManager = scripts.GetComponent<SoundManager>();
	}

	//lets the object take damage
	public void takeDamage(int value){
		//decrease health
		health -= value;
		//check if the object has died
		if (health <= 0){
			//if we have a smoke effect
			if (smoke != null){
				//create the smoke effect
				var effect = Instantiate(smoke) as GameObject;
				effect.transform.position = transform.position;
				//create the explostion effect
				var effect2 = Instantiate(explosion) as GameObject;
				effect2.transform.position = transform.position;
				//destroy the explosion after 1 second
				Destroy(effect2,1);
				//play the explosion sound
				soundManager.playExplosion(transform.position);
			}
			//destroy the object
			Destroy(gameObject);

		}
	}

	//lets the object gain health
	public void gainHealth(int value){
		//add health
		health += value;
		//check if we dont exceed max
		if (health > 100){
			health = 100;
		}
	}




}
