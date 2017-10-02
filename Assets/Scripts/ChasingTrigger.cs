using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChasingTrigger : MonoBehaviour {
	public bool canChasing = false;
    public GameObject enemy;
	public GameObject killer;

	void Start(){
		killer.SetActive (false);
	}

    void OnTriggerEnter(Collider other) {
		if(other.transform.tag == "Player") {
			killer.SetActive (true);
            //enemy.SetActive(true);
            canChasing = true;
			//transform.GetComponent<EnemyNavi> ().enabled = true;
		}
	}

}