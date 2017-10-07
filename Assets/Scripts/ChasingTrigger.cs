using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChasingTrigger : MonoBehaviour {
	public bool canChasing = false;
<<<<<<< HEAD
    public GameObject enemy;
    public 

=======
    public GameObject killer;
>>>>>>> master

    void OnTriggerEnter(Collider other) {
		if(other.transform.tag == "Player") {
            killer.SetActive(true);
            canChasing = true;
			//transform.GetComponent<EnemyNavi> ().enabled = true;
            GameObject.Find("Killer with Machete(T-pose)").GetComponent<AudioSource>().enabled = true;
		}
	}

}