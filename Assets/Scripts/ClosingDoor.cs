using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoor : MonoBehaviour {
    public GameObject closingDoor;
    public GameObject Killer;


    private void OnTriggerEnter(Collider other)
    {
		if (other.transform.tag == "Player")
		{
			closingDoor.SetActive(true);
            Killer.SetActive(false);
		}
	}
}
