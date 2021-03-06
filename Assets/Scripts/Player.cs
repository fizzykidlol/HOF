﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    //music
    private AudioSource[] music;

    //health
    public float maxHealth = 3;
    private float health;
    public bool dead = false;
    public GameObject deathScreen;
    public AudioSource lightHeartBeat;
    public AudioSource heavyHeartbeat;

    //stamina
    public float maxStamina = 100;
    public float stamina;
    public float staminaRegenRate = 0.1f;
    private float staminaRegenTimer;
    public float staminaReduceRate = 0.1f;
    private float staminaReduceTimer;
    public AudioSource breathingSound;


    //character controller
    private RigidBodyPlayerController cc;
    private Rigidbody rb;

    //walking sounds
    public GameObject walkOnStoneSound;
    public GameObject walkOnMetalSolidSound;
    public GameObject walkOnMetalHollowSound;
    private float stepTimer;
    public float stepRate = 0.5f;

    //ladder
    public bool onLadder = false;

    //pause menu
    public GameObject pauseMenu;
    public bool paused = false;
    public bool onTopMenu;

    //Checkpoints
    public checkpointGeneral checkpoint;
    public int checkpointNum;
    public Transform[] SpawnPoints;
    public Image fadeScreen;


    public Camera cam;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public MouseLook ml;

    //torch
    public float torchRegen;
    public float torchReduction;
    private float torchBattery;
    public float torchBatteryMax;
    public float torchMinimumBattery;
    public bool torchOn;
    public Light torchLight;
    public Light torchLightOuter;
    public Slider torchBatterySlider;
    public Color torchMinimumColour;
    public Color torchNormalColour;
    public GameObject torchIconPanel;
    public Image batteryBarFill;
    public flickerOnKiller flicker;

    //analytics
    private float timesDied;
    private float monsterDeaths;
    private float environmentDeaths;


    // Use this for initialization
    void Start()
    {
        checkpointNum = 0;
        health = maxHealth;
        stamina = maxStamina;
        cc = GetComponent<RigidBodyPlayerController>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(fadeIn());
        torchBattery = torchBatteryMax;
        int i = 0;
        music = new AudioSource[GameObject.FindGameObjectsWithTag("music").Length];
        foreach(GameObject musicSource in GameObject.FindGameObjectsWithTag("music"))
        {
            music[i] = musicSource.GetComponent<AudioSource>();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!dead)
        {
            regenStamina();
            reduceStamina();
            walkingSounds();
            healthAndStaminaSounds();
            pause();
            torch();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                respawn();
                fadeScreen.color = new Color(0, 0, 0, 1);
                StartCoroutine(fadeIn());
            }
        }

    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(0.5f);

        while (fadeScreen.color.a > 0)
        {
            fadeScreen.color = new Color(0,0,0, fadeScreen.color.a - 0.05f);
            yield return null;
        }
    }

    private void torch()
    {
        if (Input.GetKeyDown("f"))
        {
            if (torchOn)
            {
                torchOn = false;
            }
            else if (torchBattery > torchMinimumBattery)
            {
                torchOn = true;
            }
        }

        if (torchOn)
        {
            if (torchBattery > 0)
            {
                torchBattery -= torchReduction;
            }
            else
            {
                torchOn = false;
            }
        }
        else if (torchBattery < torchBatteryMax)
        {
            torchBattery += torchRegen;
        }
        else if (torchBattery > torchBatteryMax)
        {
            torchBattery = torchBatteryMax;
        }

        //make the torch icon disappear when fully charged and not in use
        if (torchBattery == torchBatteryMax && !torchOn)
        {
            torchIconPanel.SetActive(false);
        }
        else
        {
            torchIconPanel.SetActive(true);
        }

        if (torchBattery < torchMinimumBattery)
        {
            batteryBarFill.color = torchMinimumColour;
        }
        else
        {
            batteryBarFill.color = torchNormalColour;
        }

        torchLight.enabled = torchOn;
        torchLightOuter.enabled = torchOn;
        torchBatterySlider.value = torchBattery / torchBatteryMax;
        if (torchOn)
        {
            flicker.torchFlicker();
        }
    }

    //activate pause menu
    private void pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused && onTopMenu)
            {
                unPause();
            }
            else if (!paused)
            {
                pauseMenu.SetActive(true);
                paused = true;
                onTopMenu = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void unPause()
    {
        pauseMenu.SetActive(false);
        paused = false;
        onTopMenu = false;
        Time.timeScale = 1;

    }

    private IEnumerator DisableCursor()
    {
        yield return new WaitForEndOfFrame();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void healthAndStaminaSounds()
    {
        if (stamina < 20 && !breathingSound.isPlaying)
        {
            breathingSound.Play();
        }
        //if (health == 2 && !lightHeartBeat.isPlaying)
        //{
        //lightHeartBeat.Play();
        // }
        // else if (health == 1 && !heavyHeartbeat.isPlaying)
        //{
        // heavyHeartbeat.Play();
        // }
    }


    public void respawn()
    {
        transform.position = SpawnPoints[checkpointNum].position;
        ml.mouseLook = new Vector2(SpawnPoints[checkpointNum].eulerAngles.y, 0);
        dead = false;
        stamina = maxStamina;
        deathScreen.SetActive(false);
        health = maxHealth;
        checkpoint.resetObjects();
        torchBattery = torchBatteryMax;

        if (checkpointNum == 0)
        {
            checkpoint.resetDoor();
        }

        if (checkpointNum == 1)
        {
            checkpoint.resetEnemy();
            checkpoint.resetMachete();
            checkpoint.resetBlockage();
        }
        if (checkpointNum == 2)
        {
            checkpoint.resetLadder();
            checkpoint.resetShadow();
            checkpoint.resetAcid();
        }

        if (checkpointNum == 3)
        {
            checkpoint.resetEnemy();
            checkpoint.resetEnemy2();
            checkpoint.resetLadder();
            checkpoint.resetLadder2();
        }

    }

    private void regenStamina()
    {
        if (Time.time > staminaRegenTimer && stamina < maxStamina && !cc.sprinting && cc.grounded)
        {
            stamina += 2;
            staminaRegenTimer = Time.time + staminaRegenRate;
        }
        //staminaSlder.value = stamina / maxStamina;
    }

    private void reduceStamina()
    {
        if ((rb.velocity.x != 0 || rb.velocity.z != 0) && staminaReduceTimer < Time.time
            && cc.grounded && stamina > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                stamina -= 1;
                staminaReduceTimer = Time.time + staminaReduceRate;
                if (stamina <= 0)
                {
                    staminaRegenTimer = Time.time + 2;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && cc.grounded && stamina > 0)
        {
            stamina -= 10;
            staminaReduceTimer = Time.time + staminaReduceRate;
            if (stamina <= 0)
            {
                staminaRegenTimer = Time.time + 2;
            }
        }
    }

    private void walkingSounds()
    {
        if (cc.grounded && Time.time > stepTimer && (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")))
        {
            string sound = checkGroundMaterial();
            if (sound == "Stone")
            {
                Instantiate(walkOnStoneSound, transform.position, transform.rotation);
            }
            else if (sound == "Solid Metal")
            {
                Instantiate(walkOnMetalSolidSound, transform.position, transform.rotation);
            }
            else if (sound == "Hollow Metal")
            {
                Instantiate(walkOnMetalHollowSound, transform.position, transform.rotation);
            }

            if (cc.sprinting)
            {
                stepTimer = Time.time + stepRate / 2;
            }
            else
            {
                stepTimer = Time.time + stepRate;
            }
        }
    }

    private string checkGroundMaterial()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (hit.transform.tag == "Stone Floor" || hit.transform.tag == "Stone Ledge")
            {
                return "Stone";
            }
            else if (hit.transform.tag == "Hollow Metal Floor" || hit.transform.tag == "Hollow Metal Ledge")
            {
                return "Hollow Metal";
            }
            else if (hit.transform.tag == "Solid Metal Floor" || hit.transform.tag == "Solid Metal Ledge")
            {
                return "Solid Metal";
            }
        }
        return "Stone";
    }

    public void takeDamage(float damage, bool damageFromMonster = false)
    {
        health -= damage;
        //healthSlider.value = health / maxHealth;
        if (health <= 0)
        {
            gameOver(damageFromMonster);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Danger")
        {
            takeDamage(3);
        }
    }

    public void gameOver(bool diedByMonster)
    {
        if (diedByMonster)
        {
            monsterDeaths++;
        }
        else
        {
            environmentDeaths++;
        }
        turnOffMusic();
        timesDied++;
        dead = true;
        deathScreen.SetActive(true);
    }

    public void turnOffMusic()
    {
        foreach (AudioSource audio in music)
        {
            audio.Stop();
        }
    }

    private void OnApplicationQuit()
    {
        endOfGameEvent();
    }

    public void endOfGameEvent(bool finishedLevel = false)
    {
        Analytics.CustomEvent("Game ended", new Dictionary<string, object>
        {
            { "Number of Deaths", timesDied},
            {"Deaths to Environment", environmentDeaths },
            {"Deaths to Monster", monsterDeaths },
            {"Highest Checkpoint Reached", checkpointNum},
            {"finished game", finishedLevel},
            {"Time Played", Time.timeSinceLevelLoad}
        });
    }
}
