using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public GameObject sprintJump;
    public GameObject Sliding;
    public GameObject wallrunning;
    public GameObject interacting;

    public bool sprintJumpshown = false;
    public bool slidingShown = false;
    public bool wallrunningShown = false;
    public bool interactingShown = false;

    public float tutorialTime = 3;
    private float tutorialTimer;

	
	// Update is called once per frame
	void Update () {
        if (tutorialTimer < Time.time)
        {
            sprintJump.SetActive(false);
            Sliding.SetActive(false);
            wallrunning.SetActive(false);
            interacting.SetActive(false);
        }
    }

    public void showSprintJump()
    {
        if (!sprintJumpshown)
        {
            sprintJump.SetActive(true);
            sprintJumpshown = true;
            tutorialTimer = Time.time + tutorialTime;
        }

    }

    public void showSliding()
    {
        if (!slidingShown)
        {
            wallrunning.SetActive(false);
            Sliding.SetActive(true);
            slidingShown = true;
            tutorialTimer = Time.time + tutorialTime;
        }
    }

    public void showWallRunning()
    {
        if (!wallrunningShown)
        {
            wallrunning.SetActive(true);
            wallrunningShown = true;
            tutorialTimer = Time.time + tutorialTime;
        }
    }

    public void showInteracting()
    {
        if (!interactingShown)
        {
            Sliding.SetActive(false);
            interacting.SetActive(true);
            interactingShown = true;
            tutorialTimer = Time.time + tutorialTime;
        }
    }
}
