using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour {

    public GameObject player;
    public GameObject IntIcon;
    private bool interactableLookedAt = false;
    public ColliderDetector detector;
    public float detectionAngle = 30f;
    public bool itemDetected = false;
    private Interactable interactable;
	
	// Update is called once per frame
	void Update () {
        interactableLookedAt = false;
        if (detector.collision)
        {
            
            Vector3 targetDir = detector.returnTouchingObject().transform.position - transform.position;
            float angle = Vector3.Angle(targetDir , transform.forward);
            if (angle < detectionAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, targetDir, out hit))
                {
                    if (hit.transform.tag == "Interactable")
                    {
                        interactableLookedAt = true;
                        itemDetected = true;
                        interactable = detector.returnTouchingObject().GetComponent<Interactable>();
                    }
                }
            }
            
        }


        if (itemDetected)
        {
            if (interactable.target.transform.tag == "Newspaper" 
                && interactable.activated && Input.GetMouseButtonDown(0))
            {
                interactable.deactivateNewspaper();
            }

            else if (interactableLookedAt)
            {
                if (!interactable.activated)
                {
                    IntIcon.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        interactable.activate();
                    }
                }
                else
                {
                    IntIcon.SetActive(false);
                }
            }
            else
            {
                IntIcon.SetActive(false);
            }
        }


		
	}
}
