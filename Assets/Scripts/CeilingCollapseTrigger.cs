using System.Collections; using System.Collections.Generic; using UnityEngine;  public class CeilingCollapseTrigger : MonoBehaviour
{

	public static bool canCollapse = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			canCollapse = true;
		}
	}
}