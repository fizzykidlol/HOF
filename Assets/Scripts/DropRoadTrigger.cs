using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRoadTrigger : MonoBehaviour
{

	public static bool canDrop = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			canDrop = true;
		}
	}


}