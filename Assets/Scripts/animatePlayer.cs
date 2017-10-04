

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatePlayer : MonoBehaviour {

    private Vector3 origionalPos;
    private Animator animator;
    public RigidBodyPlayerController pc;
    public Player player;
    public WallRun wr;
    public AnimatorStateInfo state;
    public float slideMovementVertical = 0.5f;
    public float slideMovementHorizontal = 0.2f;
    public float climbVerticalMovement = 0.05f;
    public float climbHorizontalMovement = 0.05f;
    public Camera mainCamera;
    private float origionalCloseRange;
    public float increasedCloseRange = 0.12f;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        origionalPos = transform.localPosition;
        origionalCloseRange = mainCamera.nearClipPlane;
	}
	
	// Update is called once per frame
	void Update () {
        if (!player.dead)
        {
            state = animator.GetCurrentAnimatorStateInfo(0);
            if (!state.IsName("Slide") && !state.IsName("Jumping") && !state.IsName("Wallrun") && !pc.climbing)
            {
                if (pc.grounded && Input.GetKey("w")
                && !Input.GetKey("d") && !Input.GetKey("a") && !state.IsName("Slide"))
                {
                    if (pc.sprinting && !state.IsName("Run"))
                    {
                        Run();
                    }
                    else if (!state.IsName("Walking") && !pc.sprinting)
                    {
                        Walk();
                    }

                }

                if ((Input.GetKeyUp("w") && (state.IsName("Walking") || state.IsName("Run"))) ||
                    (Input.GetKeyUp("d") && state.IsName("RightStrafe")) ||
                    (Input.GetKeyUp("a") && state.IsName("LeftStrafe")))
                {
                    Idle();
                }

                if (pc.grounded && Input.GetKey("d") && !state.IsName("RightStrafe"))
                {
                    RightStrafe();
                }

                if (pc.grounded && Input.GetKey("a") && !state.IsName("LeftStrafe"))
                {
                    LeftStrafe();
                }
            }

            if (!state.IsName("Climb") && !state.IsName("Slide"))
            {
                transform.localPosition = origionalPos;
                mainCamera.nearClipPlane = origionalCloseRange;
            }

            if (pc.grounded && Input.GetKeyDown("q") && !state.IsName("Slide"))
            {
                Slide();
                transform.position += transform.up * slideMovementVertical;
                transform.position += -transform.forward * slideMovementHorizontal;
            }
            if (pc.grounded && Input.GetKeyUp("q"))
            {
                Idle();
            }


            if (pc.grounded && Input.GetKey(KeyCode.Space) && !state.IsName("Jumping"))
            {
                Jump();
            }

            if (pc.climbing && (Input.GetKey("w") || Input.GetKey("s")) && !state.IsName("Climb"))
            {
                Climb();
                transform.localPosition = origionalPos + Vector3.up * climbVerticalMovement + Vector3.forward * climbHorizontalMovement;
                mainCamera.nearClipPlane = increasedCloseRange;
            }

            if (pc.climbing)
            {
                if (Input.GetKey("w"))
                {
                    animator.SetFloat("ClimbSpeed", 1f);
                }
                else if (Input.GetKey("s"))
                {
                    animator.SetFloat("ClimbSpeed", -1f);
                }
                else if (Input.GetKeyUp("w") || Input.GetKeyUp("s"))
                {
                    animator.SetFloat("ClimbSpeed", 0f);
                }
            }
        }
    }

    public void Idle()
    {
        animator.Play("Idle");
    }

    public void Walk()
    {
        animator.Play("Walking");
    }

    public void Run()
    {
        animator.Play("Run");
    }

    public void Jump()
    {
        animator.Play("Jumping");
    }

    public void Slide()
    {
        animator.Play("Slide");
    }

    public void LeftStrafe()
    {
        animator.Play("LeftStrafe");
    }

    public void RightStrafe()
    {
        animator.Play("RightStrafe");
    }

    public void Wallrun()
    {
        animator.Play("Wallrun");
    }

    public void Climb()
    {
       animator.Play("Climb");
    }
}
