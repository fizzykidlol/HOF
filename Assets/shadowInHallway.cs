using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowInHallway : MonoBehaviour {

    public GameObject killer;
    public Animator anim;
    public float walkSpeed = 4;
    public float timeToDestruction = 1;
    private float destructionTimer;
    public bool on = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (on)
        {
            killer.transform.position += killer.transform.forward
                * walkSpeed * Time.deltaTime;
            if (destructionTimer < Time.time)
            {
                killer.SetActive(false);
                on = false;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !on)
        {
            on = true;
            destructionTimer = Time.time + timeToDestruction;
            anim.Play("Walk");
        }        
    }
}
