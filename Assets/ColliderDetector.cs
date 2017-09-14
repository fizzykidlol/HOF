using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour {

    public bool Collision = false;
    public string targetTag;
    private GameObject currentTarget;


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == targetTag)
        {
            Collision = true;
            currentTarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == targetTag)
        {
            Collision = false;
        }
    }

    public GameObject returnTouchingObject()
    {
        return currentTarget;
    }
}
