using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepsOnRoof : MonoBehaviour {

    public GameObject soundObject;
    private AudioSource sound;
    private Vector3 origionalpos;
    private bool on = false;
    private float stopTimer;
    public float timeToStop = 3;
    public float speed = 2;

	// Use this for initialization
	void Start () {
        sound = soundObject.GetComponent<AudioSource>();
        origionalpos = soundObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (on && Time.time < stopTimer)
        {
            soundObject.transform.position += soundObject.transform.forward * Time.deltaTime;
        }
        else
        {
            sound.Stop();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !on)
        {
            on = true;
            sound.Play();
            stopTimer = Time.time + timeToStop;
        }
    }

    public void reset()
    {
        soundObject.transform.position = origionalpos;
        on = false;
        sound.Stop();
    }
}
