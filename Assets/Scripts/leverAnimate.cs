using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverAnimate : MonoBehaviour {

    public bool on = false;
    private Vector3 origionalRotation;
    public float targetRotation = -70;

	// Use this for initialization
	void Start () {
        origionalRotation = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            animate();
        }
    }

    public void animate()
    {
        var target = Quaternion.Euler(0, 0, targetRotation);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target,
                    10 * Time.deltaTime);
    }

    public void ResetLever()
    {
        on = false;
        transform.eulerAngles = origionalRotation;
    }
}
