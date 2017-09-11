using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {
    private Vector3 startingPos;
    private NavMeshAgent myAgent;
    private Animator myAnimator;
    public Transform target;
    public ChasingTrigger trigger;
    public AudioSource attackSound;

    public bool chaseTarget = true;
    public float stoppingDistance = 2.5f;
    public float delayBetweenAttacks = 1.5f;
   
    private float attackCooldown;

    private float distanceFromTarget;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startingPos = transform.position;
        myAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
        myAgent.stoppingDistance = stoppingDistance;
	}
	
	// Update is called once per frame
	void Update () {
        
		if (trigger.canChasing)
		{    ChaseTarget();
			
            myAnimator.Play("Run");
		}
		else
		{
            myAnimator.Play("idle");
		}
		
		transform.LookAt (target.position);
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y, 0);
	}
    void ChaseTarget(){
        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        if (distanceFromTarget >= stoppingDistance){
            chaseTarget = true;
        }
        else{
            chaseTarget = false;
            Attack();
        }
        if(chaseTarget){
            myAgent.SetDestination(target.position);
            myAnimator.SetBool("isChasing", true);
        }
        else{
            myAnimator.SetBool("isChasing", false);
        }
    }
    void Attack(){
        if(Time.time > attackCooldown){
            Debug.Log("Attack!");
            target.GetComponent<Player>().takeDamage(1);
            myAnimator.SetTrigger("Attack");
            attackCooldown = Time.time + delayBetweenAttacks;
            attackSound.Play();
        }
    }

    public void Reset()
    {
        myAgent.Warp(startingPos);
        trigger.canChasing = false;
        gameObject.SetActive(true);
    }
}
