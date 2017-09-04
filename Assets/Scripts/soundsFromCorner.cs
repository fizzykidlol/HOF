using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsFromCorner : MonoBehaviour {

    public AudioSource crashingSounds;
    public GameObject extiguisher;
    public Vector3 debrisFling = new Vector3(0, 3, 3);

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
            crashingSounds.Play();
            extiguisher.GetComponent<Rigidbody>().AddRelativeForce(debrisFling);
        }
    }
}
