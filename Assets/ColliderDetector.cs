using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour {

    public string targetTag;
    public bool collision;
    private GameObject currentTarget;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == targetTag)
        {
            currentTarget = other.gameObject;
            collision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == targetTag)
        {
            collision = false;
        }
    }

    public GameObject returnTouchingObject()
    {
        return currentTarget;
    }
}
