using System.Collections; using System.Collections.Generic; using UnityEngine;  public class CeilingCollapse : MonoBehaviour
{

	public Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void Update()
	{
		if (CeilingCollapseTrigger.canCollapse)
		{
			rb.isKinematic = false;
		}


	} }