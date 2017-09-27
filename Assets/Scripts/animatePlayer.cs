

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
    public float climbVerticalMovement = 0.1f;
    public Camera mainCamera;
    private float origionalCloseRange;
    public float increasedCloseRange;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        origionalPos = transform.localPosition;
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
                //Climb();
                //transform.localPosition = origionalPos + Vector3.up * climbVerticalMovement;
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
