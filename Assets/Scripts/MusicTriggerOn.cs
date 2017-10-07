using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerOn : MonoBehaviour {

	public AudioSource sound;




	private void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.tag == "Player")
		{

				sound.Play ();
				GetComponent<BoxCollider> ().enabled = false;
			} 

	    }
}
		




