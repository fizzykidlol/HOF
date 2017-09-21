using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createSoundObject : MonoBehaviour {

    public GameObject soundObject;

    void createObject()
    {
        Instantiate(soundObject, transform.position, transform.rotation);
    }
}
