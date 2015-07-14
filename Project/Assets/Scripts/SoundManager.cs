using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


	public Transform player;

	public AudioClip gunShot;



	public void playGunShot(){
		playSound(gunShot);
	}

	private void playSound(AudioClip clip){
		AudioSource.PlayClipAtPoint(clip, player.position);
	}

	

}
