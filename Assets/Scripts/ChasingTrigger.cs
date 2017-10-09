using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChasingTrigger : MonoBehaviour {
	public bool canChasing = false;
    public GameObject killer;

    void OnTriggerEnter(Collider other) {
		if(other.transform.tag == "Player") {
            killer.SetActive(true);
            canChasing = true;
			//transform.GetComponent<EnemyNavi> ().enabled = true;
		}
	}

}