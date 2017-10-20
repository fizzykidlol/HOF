using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePart4 : MonoBehaviour {

    public LevelRenderer r;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            r.fourthSection();
        }
    }
}
