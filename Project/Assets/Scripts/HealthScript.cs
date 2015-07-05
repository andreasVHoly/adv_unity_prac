using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {


	public int health = 100;


	
	public void takeDamage(int value){
		health -= value;
		if (health <= 0){
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
