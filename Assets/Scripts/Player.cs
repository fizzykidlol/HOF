using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    //health
    public float maxHealth = 3;
    private float health;
    public bool dead = false;
    public GameObject deathScreen;
    public GameObject damage1;
    public GameObject damage2;

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

    public Camera cam;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public MouseLook ml;

	//Music
	public AudioSource music;
	public AudioSource music2;
	public GameObject musicTrigger1;
	public GameObject musicTrigger2;
	public GameObject musicTrigger3;
	private BoxCollider boxCol;
	private BoxCollider boxCol2;
	private BoxCollider boxCol3;


    // Use this for initialization
    void Start () {
        health = maxHealth;
        stamina = maxStamina;
        cc = GetComponent<RigidBodyPlayerController>();
        rb = GetComponent<Rigidbody>();
		boxCol = musicTrigger1.GetComponent<BoxCollider> ();
		boxCol2 = musicTrigger2.GetComponent<BoxCollider> ();
		boxCol3 = musicTrigger3.GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!dead)
        {
            regenStamina();
            reduceStamina();
            //walkingSounds();
            healthAndStaminaSounds();
            pause();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                respawn();
            }
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
        changeHealthUI();

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
    
    public void playWalkOnStoneSound()
    {
        Instantiate(walkOnStoneSound, transform.position, transform.rotation);
    }

    private void walkingSounds()
    {
        if (cc.grounded && Time.time > stepTimer && (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s")  || Input.GetKey("d")))
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

    public void takeDamage(float damage)
    {
        health -= damage;
        changeHealthUI();
        //healthSlider.value = health / maxHealth;
        if (health <= 0)
        {
            gameOver();
        }
    }

    public void changeHealthUI()
    {
        if (health == 2)
        {
            damage1.SetActive(true);
        }
        if (health == 1)
        {
            damage2.SetActive(true);
            damage1.SetActive(false);
        }
        if (health == 0 || health == 3)
        {
            damage1.SetActive(false);
            damage2.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Danger")
        {
            takeDamage(3);
        }
    }

    public void gameOver()
    {
		boxCol.enabled = true;
		boxCol2.enabled = true;
		boxCol3.enabled = true;
		music.Stop ();
		music2.Stop ();
        dead = true;
        deathScreen.SetActive(true);
    }


            


}
