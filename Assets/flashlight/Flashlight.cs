using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    //Variables
    public GameObject flashlight;
    public GameObject fLight;

    private GameObject pickingBattery;
    int amountOfBatteries;
    public float energy;
    public float batteryEnergy;
    public float decreasedEnergy;

    private float energySpent;

    bool equipped;
    public bool useInputToPickup;
    bool triggering;

   
     void Update()
    {
        //Equipping and unequipping
        if (Input.GetKeyDown(KeyCode.F))
            equipped = !equipped;
        //If the flashlight is equipped
        if(equipped){
            //Enable the flashlight
            flashlight.SetActive(true);

            //If flashlight has energy greater than zero
            if (energy > 0)
            {
                //Enable the fLight(light itself for our flashlight)
                fLight.SetActive(true);
                //decrease energy by"decreasedEnergy" variable each second
                energy -= decreasedEnergy * Time.deltaTime;
                //Increase energySpent by 'decreasedEnergy' variable each second
                energySpent += decreasedEnergy * Time.deltaTime;
                //If energySpent for each battey reaches the maximum extent..
                if(energySpent >= batteryEnergy){

                    //decrease amount of batteries we have and set energySpent back to 0
                    amountOfBatteries--;
                    energySpent = 0;
                }
            }else{
                fLight.SetActive(false);
            }
            //Flashlight not equipped
        }else{
            flashlight.SetActive(false);
        }
        if (useInputToPickup)
        {
            if (triggering)
            {
                if (Input.GetKeyDown(KeyCode.E))
                    PickupBattery();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Battery")
        {
            if (useInputToPickup)
            {
                pickingBattery = other.gameObject;
                triggering = true;
            }else{
				pickingBattery = other.gameObject;
				PickupBattery();
            }
        }
    }

   
    //pick up battery
    public void PickupBattery(){
        amountOfBatteries++;
        energy = batteryEnergy * amountOfBatteries;
        Destroy(pickingBattery);
    }
}