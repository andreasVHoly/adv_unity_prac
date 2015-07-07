using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {


	public GameObject smoke;

	public int health = 100;


	
	public void takeDamage(int value){
		health -= value;
		if (health <= 0){
			if (smoke != null){
				var effect = Instantiate(smoke) as GameObject;
				effect.transform.position = transform.position;

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
