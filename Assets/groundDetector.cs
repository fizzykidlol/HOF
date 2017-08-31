using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDetector : MonoBehaviour {

    public bool grounded;

	

    private void OnTriggerStay(Collider other)
    {
       if (other.transform.tag == "Ledge")
        {
            grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Ledge")
        {
            grounded = false;
        }
    }


    void Update()
    {
        
    }
}
