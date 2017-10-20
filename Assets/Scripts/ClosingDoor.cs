using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoor : MonoBehaviour {
    public GameObject closingDoor;
    public LevelRenderer renderManager;
    public GameObject Killer;
    public AudioSource collapse;
    public bool oneShot = false;

    private void OnTriggerEnter(Collider other)
    {
		if (other.transform.tag == "Player" && ! oneShot)
		{
            collapse.Play();
			closingDoor.SetActive(true);
            Killer.SetActive(false);
            oneShot = true;
            renderManager.thirdSection();
		}
	}
}
