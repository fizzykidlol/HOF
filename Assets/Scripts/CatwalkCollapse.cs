using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatwalkCollapse : MonoBehaviour {

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			rb.isKinematic = false;
			CameraShake.isShaking = true;
		}
	}
}
