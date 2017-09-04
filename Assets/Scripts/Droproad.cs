using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droproad : MonoBehaviour
{


	public Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void Update()
	{
		if (DropRoadTrigger.canDrop)
		{
			rb.isKinematic = false;
		}


	}
}