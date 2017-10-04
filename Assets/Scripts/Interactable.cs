using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public GameObject target;
    public leverAnimate lever;
    public AnimateButton button;
    public newspaper newspaper;
    public bool activated = false;

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
                activated = true;
                button.on = true;
                break;

            case ("Ladder"):
                target.GetComponent<DropdownLadder>().drop();
                activated = true;
                lever.on = true;
                break;

            case ("Water"):
                target.GetComponent<WaterFill>().fill();
                activated = true;
                break;

            case ("Newspaper"):
                newspaper.activate();
                activated = true;
                break;

            default:
                break;
        }       
    }

    public void deactivateNewspaper()
    {
        if (target.transform.tag == "Newspaper")
        {
            newspaper.deactivate();
            activated = false;
        }
    }
}
