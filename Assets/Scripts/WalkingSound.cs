﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour {

    public GameObject playerSFX;

	// Use this for initialization
	void Start () {
        float pitch = Random.Range(0.8f, 1);
        AudioSource source = GetComponent<AudioSource>();
        source.pitch = pitch;
        playerSFX = GameObject.FindGameObjectWithTag("SFX");
        source.volume = SettingsManager.SFXvolume;
        source.Play();
        Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
