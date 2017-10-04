using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSounds : MonoBehaviour {

    public AudioSource[] sounds;
    public bool on = false;
    public float soundRate;
    private float soundTimer;
    public float randomCap = 0.5f;
    

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (on)
        {
            if (Time.time > soundTimer)
            {
                int rand = (int)Random.Range(0, sounds.Length);
                sounds[rand].Play();
                soundTimer = Time.time + soundRate + Random.Range(0, randomCap);
            }
        }
	}
}
