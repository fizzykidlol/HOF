using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquaketrigger : MonoBehaviour
{

	EarthquakeShaker c2 = null;



	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			c2 = GameObject.Find("Player").GetComponent<EarthquakeShaker>().enabled = true;

		}

	}



}
