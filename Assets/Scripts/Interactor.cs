using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour {

    public GameObject player;
    public float interactionDistance = 1;
    public GameObject[] interactables;
    public GameObject IntIcon;
    private bool interactableLookedAt = false;


	// Use this for initialization
	void Start () {
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
	}
	
	// Update is called once per frame
	void Update () {
        interactableLookedAt = false;
        foreach (GameObject i in interactables)
        {
            if (Vector3.Distance(player.transform.position, i.transform.position) < interactionDistance)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.transform.tag == "Interactable")
                    {
                        interactableLookedAt = true;
                        if (Input.GetMouseButtonDown(0))
                        {
                            i.GetComponent<Interactable>().activate();
                        }
                    }
                }
            }
        }

        if (interactableLookedAt)
        {
            IntIcon.SetActive(true);
        }
        else
        {
            IntIcon.SetActive(false);
        }
		
	}
}
