using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplatform : MonoBehaviour
{

	bool isFalling = false;
	float downSpeed = 0;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			isFalling = true;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (isFalling)
		{
			downSpeed += Time.deltaTime / 20;
			transform.position = new Vector3(transform.position.x,
											transform.position.y - downSpeed,
											transform.position.z);

		}
	}
}
