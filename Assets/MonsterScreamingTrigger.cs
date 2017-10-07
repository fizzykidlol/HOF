using UnityEngine;
using System.Collections;

public class MonsterScreamingTrigger : MonoBehaviour {

	public float Volume;
	public AudioSource audio;
	public bool alreadyPlayed = false;
	void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter()
	{
		if (!alreadyPlayed)
		{
            audio.Play();
			alreadyPlayed = true;
		}
	}
}