using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour {

    public bool opening = false;
    public float raiseSpeed = 1;
    public float targetHeight = 1;
    private float targetPosition;
    private Vector3 origionalPos;
    public AudioSource gateOpenning;
    private bool closing = false;
    public GameObject closingHitbox;
    public LevelRenderer renderermanager;

	// Use this for initialization
	void Start () {
        targetPosition = transform.position.y + targetHeight;
        origionalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (opening && transform.position.y < targetPosition)
        {
            Vector3 position = new Vector3(0, raiseSpeed, 0) 
                * Time.deltaTime;
            transform.position += position;
            if (transform.position.y > targetPosition)
            {
                gateOpenning.Stop();
            }
        }
        if (closing && Vector3.Distance(transform.position, origionalPos) > 0.1)
        {
            float step = raiseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, origionalPos, step);
            if (Vector3.Distance(transform.position, origionalPos) < 0.1)
            {
                transform.position = origionalPos;
                renderermanager.secondSection();
            }
        }
	}

    public void open()
    {
        closing = false;
        opening = true;
        gateOpenning.Play();
        closingHitbox.SetActive(false);
    }
    public void close()
    {if (closing == false)
        {
            closing = true;
            opening = false;
            gateOpenning.Play();
            closingHitbox.SetActive(true);
        }
    }

}
