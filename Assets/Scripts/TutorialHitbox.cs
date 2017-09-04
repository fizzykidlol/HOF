using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHitbox : MonoBehaviour {

    public string tutorial;
    public TutorialManager manager;

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
            switch (tutorial)
            {
                case "wallrunning":
                    manager.showWallRunning();
                    break;

                case "sliding":
                    manager.showSliding();
                    break;

                case "interacting":
                    manager.showInteracting();
                    break;
            }
        }
    }
}
