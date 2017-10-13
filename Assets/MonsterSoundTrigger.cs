using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSoundTrigger : MonoBehaviour {

    public MonsterSounds sounds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            sounds.on = true;
        }
    }
}
