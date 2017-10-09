using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Vector3 startingPos;
    private NavMeshAgent myAgent;
    private Animator myAnimator;
    public Transform target;
    public ChasingTrigger trigger;
    public AudioSource macheteSound;
    private AnimatorStateInfo state;

    public bool chaseTarget = true;
    public float stoppingDistance = 2.5f;
    public float delayBetweenAttacks = 1.5f;

    private float attackCooldown;

    private float distanceFromTarget;

    // Use this for initialization
    void Start()
    {
		gameObject.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startingPos = transform.position;
        myAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
        myAgent.stoppingDistance = stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        state = myAnimator.GetNextAnimatorStateInfo(0);
        if (trigger.canChasing)
        {
            gameObject.SetActive(true);
            ChaseTarget();
        }
        else if (!state.IsName("attack"))
        {
            myAnimator.Play("idle");
        }

        if (chaseTarget && !state.IsName("walk") && !state.IsName("attack"))
        {
            myAnimator.Play("walk");
        }

        transform.LookAt(target.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
    void ChaseTarget()
    {
        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        if (distanceFromTarget >= stoppingDistance)
        {
            chaseTarget = true;
            
        }

        else
        {
            chaseTarget = false;
            Attack();
        }

        if (chaseTarget)
        {
            myAgent.SetDestination(target.position);
            //myAnimator.SetBool("isChasing", true);
        }
        //else
        //{
        //    myAnimator.SetBool("isChasing", false);
        //}
    }
    void Attack()
    {
        if (Time.time > attackCooldown)
        {
            Debug.Log("Attack!");
            //myAnimator.SetTrigger("Attack");
            myAnimator.Play("attack");
            attackCooldown = Time.time + delayBetweenAttacks;
        }
    }

    void DamagePlayer()
    {
        target.GetComponent<Player>().takeDamage(1);
        macheteSound.Play();
    }

    public void Reset()
    {
        myAgent.Warp(startingPos);
        trigger.canChasing = false;
        gameObject.SetActive(false);
    }
}
