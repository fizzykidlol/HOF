using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnWalkway : MonoBehaviour {

    public GameObject enemy;
    public Transform turnPoint;
    public Transform despawnPoint;
    public bool on = false;
    public float walkSpeed = 3;
    private bool reachedPoint1 = false;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (on)
        {
            if (!reachedPoint1)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position,
                    turnPoint.position, walkSpeed * Time.deltaTime);
                if (Vector3.Distance(enemy.transform.position, turnPoint.transform.position) < 0.1f)
                {
                    reachedPoint1 = true;
                    enemy.transform.eulerAngles = new Vector3(0, -90, 0);
                }
            }
            else
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position,
                    despawnPoint.position, walkSpeed * Time.deltaTime);
                if (Vector3.Distance(enemy.transform.position, despawnPoint.transform.position) < 0.1f)
                {
                    enemy.SetActive(false);
                }
            }
        }
	}
}
