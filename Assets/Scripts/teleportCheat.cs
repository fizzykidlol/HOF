using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportCheat : MonoBehaviour {

    public Transform location1;
    public Transform location2;
    public Transform location3;
    public Transform location4;
	public Transform location5;
    public Transform locationPersonal;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = location1.position;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = location2.position;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = location3.position;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.position = location4.position;
        }
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			transform.position = location5.position;
		}
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.position = locationPersonal.position;
        }
    }
}
