using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour {

    public GameObject player;
    public GameObject IntIcon;
    private bool interactableLookedAt = false;
    public ColliderDetector detector;
    public float detectionAngle = 30f;

	
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
                    }
                }
            }
            
        }


        if (interactableLookedAt)
        {
            IntIcon.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                detector.returnTouchingObject().GetComponent<Interactable>().activate();
            }
        }
        else
        {
            IntIcon.SetActive(false);
        }
		
	}
}
