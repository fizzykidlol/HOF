using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

    public GameObject player;
    public static bool canRespawn = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
            canRespawn = true;

		}

	}

}
