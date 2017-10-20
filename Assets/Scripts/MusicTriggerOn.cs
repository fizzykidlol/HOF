using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerOn : MonoBehaviour {

	public AudioSource sound;
    public bool on = false;
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (player.dead)
        {
            on = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            if (!on)
            {
                sound.Play();
                on = true;
            }
        }
    }
}
		




