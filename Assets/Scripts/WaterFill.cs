using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFill : MonoBehaviour {

    public Transform target;
    public bool on = false;
    public float fillSpeed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (on && transform.position.y < target.position.y)
        {
            Vector3 position = new Vector3(0, fillSpeed, 0) 
                * Time.deltaTime;
            transform.position += position;
        }
		
	}

    public void fill()
    {
        on = true;
    }
}
