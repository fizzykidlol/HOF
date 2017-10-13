using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class analyticsManager : MonoBehaviour {
    public static analyticsManager instance = null;
    public bool analyticsOn = false;

	
	void Awake () {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
