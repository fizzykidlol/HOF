using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRenderer : MonoBehaviour {

    public GameObject part1;
    public GameObject part21;
    public GameObject part22;
    public GameObject part31;
    public GameObject part32;
    public GameObject part41;
    public GameObject part42;
    public GameObject part43;

    // Use this for initialization
    void Start () {
        firstSection();
	}

    public void activateAll()
    {
        part1.SetActive(true);
        part21.SetActive(true);
        part22.SetActive(true);
        part31.SetActive(true);
        part32.SetActive(true);
        part41.SetActive(true);
        part42.SetActive(true);
        part43.SetActive(true);
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("first constants"))
        {
            item.SetActive(true);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("part 1"))
        {
            item.SetActive(true);
        }
    }

    public void firstSection()
    {
        part22.SetActive(false);
        part31.SetActive(false);
        part32.SetActive(false);
        part41.SetActive(false);
        part42.SetActive(false);
        part43.SetActive(false);
    }

    public void secondSection()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("part 1"))
        {
            item.SetActive(false);
        }
        part1.SetActive(false);
        part22.SetActive(true);
        part31.SetActive(true);
    }

    public void thirdSection()
    {
        part21.SetActive(false);
        part22.SetActive(false);
        part32.SetActive(true);
        part41.SetActive(true);
    }
    public void fourthSection()
    {
        part31.SetActive(false);
        part32.SetActive(false);
        part42.SetActive(true);
        part43.SetActive(true);
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("first constants"))
        {
            item.SetActive(false);
        }
    }
	
}
