using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnKillerOff : MonoBehaviour {

    public GameObject killer;

    private void OnTriggerEnter(Collider other)
    {
        killer.SetActive(false);
    }
}
