using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGame : MonoBehaviour {

    public float quitTime = 5f;
    private float quitTimer;

	// Use this for initialization
	void Start () {
        quitTimer = Time.time + quitTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > quitTimer)
        {
            Application.Quit();
        }
	}

}
