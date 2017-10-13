using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour {

    public bool on = false;
    public float raiseSpeed = 1;
    public float targetHeight = 1;
    private float targetPosition;
    public AudioSource gateOpenning;

	// Use this for initialization
	void Start () {
        targetPosition = transform.position.y + targetHeight;
	}
	
	// Update is called once per frame
	void Update () {
		if (on && transform.position.y > targetPosition)
        {
            Vector3 position = new Vector3(0, raiseSpeed, 0) 
                * Time.deltaTime;
            transform.position += position;
            
        }
	}

    public void open()
    {
        on = true;
        gateOpenning.Play();
    }
}
