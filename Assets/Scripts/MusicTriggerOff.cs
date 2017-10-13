using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerOff : MonoBehaviour {

	public AudioSource sound;

		

	
	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			StartCoroutine ("fadeOut");
			GetComponent<BoxCollider> ().enabled = false;
		}
	}

	IEnumerator fadeOut()
	{
		while(sound.volume > 0.01f){
			sound.volume -= Time.deltaTime / 2.0f;
			yield return null;
		}

		sound.volume = 0;
		sound.Stop ();
	}
}