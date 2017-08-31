using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSlamTrigger : MonoBehaviour {

    public SlammingDoor door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            door.slam();
        }
        
    }
}
