using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateButton : MonoBehaviour {

    public Transform button;
    public AudioSource buttonPressingSound;
    public float buttonSpeed = 1f;
    public float targetPoint = -0.3f;
    public bool on = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (on)
        {
            
            pushButton();
        }
	}

    public void pushButton()
    {
        if (button.localPosition.y > targetPoint)
        {
            button.position += -button.up * buttonSpeed * Time.deltaTime;
            buttonPressingSound.Play();
        }
        
    }


}
