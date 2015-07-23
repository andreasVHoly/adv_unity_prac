using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {



	public GameObject scripts;
	private SoundManager soundManager;


	public GameObject smoke;
	public GameObject explosion;

	public int health = 100;

	void Start(){
		soundManager = scripts.GetComponent<SoundManager>();
		print(soundManager);
	}
	
	public void takeDamage(int value){
		health -= value;
		if (health <= 0){
			if (smoke != null){
				var effect = Instantiate(smoke) as GameObject;
				effect.transform.position = transform.position;
				var effect2 = Instantiate(explosion) as GameObject;
				effect2.transform.position = transform.position;
				Destroy(effect2,1);
				soundManager.playExplosion(transform.position);
			}
			Destroy(gameObject);

		}
	}

	public void gainHealth(int value){
		health += value;
		if (health > 100){
			health = 100;
		}
	}




}
