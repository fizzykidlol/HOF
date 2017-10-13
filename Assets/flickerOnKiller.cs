using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerOnKiller : MonoBehaviour {

    public GameObject[] monsters;
    private Camera mainCamera;
    public Light torch;
    public Light outerTorch;
    public bool flicker = false;
    public bool enemyDetected;
    public float flickerRate = 0.1f;
    private float flickerTimer;

	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
	}

    public void torchFlicker()
    {
        flicker = false;
        enemyDetected = false;
        foreach (GameObject monster in monsters)
        {
            Vector3 targetDir = monster.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
            if (angle < mainCamera.fieldOfView)
            {
                enemyDetected = true;
                RaycastHit hit;
                if (Physics.Linecast(transform.position, monster.transform.position, out hit))
                {
                    if (hit.transform.tag == "enemy")
                    {
                        flicker = true;
                    }
                }
            }
        }

        if (flicker)
        {
            if (flickerTimer < Time.time)
            {
                flickerTimer = Time.time + flickerRate;
                if (torch.enabled)
                {
                    torch.enabled = false;
                    outerTorch.enabled = false;
                }
                else
                {
                    torch.enabled = true;
                    outerTorch.enabled = true;
                }
            }
        }
        else
        {
            torch.enabled = true;
            outerTorch.enabled = true;
        }
    }
}
