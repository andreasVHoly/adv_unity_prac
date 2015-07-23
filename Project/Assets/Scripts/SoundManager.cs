using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {




	public AudioClip gunShot;
	public AudioClip explosion;


	public void playGunShot(Vector3 position){
		playSoundAtPosition(gunShot, position);
	}

	public void playExplosion(Vector3 position){
		playSoundAtPosition(explosion, position);
	}




	private void playSoundAtPosition(AudioClip clip, Vector3 pos){
		AudioSource.PlayClipAtPoint(clip, pos);
	}

	

}
