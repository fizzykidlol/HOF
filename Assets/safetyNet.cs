using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safetyNet : MonoBehaviour {

    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.position = teleportPoint.position;
        }
    }
}
