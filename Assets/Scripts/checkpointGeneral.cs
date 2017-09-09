using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointGeneral : MonoBehaviour {

    public Transform spawn;

    
    public AI killer;
    public AI killer2;
    public GameObject[] resetList;
    public Vector3[] OriginalPos;
    public ChasingTrigger enemyTrigger;
    public DropdownLadder ladder1;
    public leverAnimate lever1;
    public DropdownLadder ladder2;
    public leverAnimate lever2;
    public shadowInHallway shadow;
    public gate gate;
    public macheteHallway machete;
    public GameObject closingDoor;
    public ClosingDoor closingDoorTrigger;
    public acidTrapTrigger acid;


	// Use this for initialization
	void Start () {
        int i = 0;
        OriginalPos = new Vector3[resetList.Length];
		foreach (GameObject obj in resetList)
        {
            OriginalPos[i] = obj.transform.position;
            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resetObjects()
    {
        int i = 0;
        foreach (GameObject obj in resetList)
        {
            obj.transform.position = OriginalPos[i];
            i++;
        }
    }

    public void resetEnemy()
    {
        killer.Reset();
    }

    public void resetEnemy2()
    {
        killer2.Reset();
    }

    public void resetLadder()
    {
        ladder1.on = false;
        lever1.ResetLever();
    }

    public void resetLadder2()
    {
        ladder2.on = false;
        lever2.ResetLever();
    }

    public void resetShadow()
    {
        shadow.on = false;
        shadow.killer.SetActive(true);
        shadow.anim.Play("idle");
    }

    public void resetDoor()
    {
        gate.on = false;
    }

    public void resetMachete()
    {
        machete.activated = false;
    }

    public void resetBlockage()
    {
        closingDoor.SetActive(false);
        closingDoorTrigger.oneShot = false;
    }

    public void resetAcid()
    {
        acid.on = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<Player>().checkpointNum++;
            other.GetComponent<Player>().checkpoint = this;
            GetComponent<BoxCollider>().enabled = false;
        }
    }

}
