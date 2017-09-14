using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour {

    public Transform Target;
    private GameObject player;
    private bool playerLock = false;
    public bool transitionLock;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (playerLock && player.transform.position.y > Target.position.y)
        {
            float step = 4 * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, Target.position, step);
            transitionLock = true;
            player.GetComponent<RigidBodyPlayerController>().climbing = false;
        }

        if (Vector3.Distance(player.transform.position, Target.position) < 0.1f)
        {
            playerLock = false;
            player.GetComponent<RigidBodyPlayerController>().rb.useGravity = true;
            transitionLock = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall Collider")
        {
            playerLock = true;
            player.GetComponent<RigidBodyPlayerController>().climbing = true;
            player.GetComponent<RigidBodyPlayerController>().rb.useGravity = false;
            player.GetComponent<RigidBodyPlayerController>().rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Wall Collider" && !transitionLock)
        {
            playerLock = false;
            player.GetComponent<RigidBodyPlayerController>().climbing = false;
            player.GetComponent<RigidBodyPlayerController>().rb.useGravity = true;
        }
    }
}
