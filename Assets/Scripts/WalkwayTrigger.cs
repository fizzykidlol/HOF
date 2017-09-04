using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkwayTrigger : MonoBehaviour {

    public EnemyOnWalkway target;
    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target.on = true;
            anim.Play("Walk");
        }
    }
}
