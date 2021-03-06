﻿using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	

	public Transform playerTransform;
	//sound clips
	public AudioClip gunShot;
	public AudioClip explosion;
	public AudioClip UISound;
	

	//quick acces methods
	public void playUISound(){
		playSoundAtPlayer(UISound);
	}

	public void playGunShot(){
		playSoundAtPlayer(gunShot);
	}

	public void playExplosion(Vector3 position){
		playSoundAtPosition(explosion, position);
	}

	//play at the players position
	public void playSoundAtPlayer(AudioClip clip){
		AudioSource.PlayClipAtPoint(clip, playerTransform.position);
	}

	//play at a given position
	private void playSoundAtPosition(AudioClip clip, Vector3 pos){
		AudioSource.PlayClipAtPoint(clip, pos);
	}

	

}
