using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownLadder : MonoBehaviour {

    public bool on = false;
    public float dropSpeed;
    public AudioSource dropStart;
    public AudioSource dropEnd;
    private bool dropStartPlayed = false;
    private bool dropEndPlayed = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (on && transform.localPosition.y > 0)
        {
            if (!dropStartPlayed)
            {
                dropStart.Play();
                dropStartPlayed = true;
            }
            Vector3 position = new Vector3(0, -dropSpeed, 0) * Time.deltaTime;
            transform.position += position;
        }
        else if (!dropEndPlayed)
        {
            //dropStart.Play();
            dropEndPlayed = true;
        }
	}

    public void drop()
    {
        on = true;
    }
}
