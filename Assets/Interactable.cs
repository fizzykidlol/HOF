using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public GameObject target;
    public leverAnimate lever;
    public AnimateButton button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activate()
    {
        switch (target.transform.tag)
        {
            case ("Gate"):
                target.GetComponent<gate>().open();
                button.on = true;
                break;

            case ("Ladder"):
                target.GetComponent<DropdownLadder>().drop();
                lever.on = true;
                break;

            case ("Water"):
                target.GetComponent<WaterFill>().fill();
                break;

            default:
                break;
        }
    }
}
