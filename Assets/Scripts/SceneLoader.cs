using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    public GameObject loadingText;
    public GameObject continueText;
    public Slider loadingBar;
    public int level;
    AsyncOperation async;

    // Use this for initialization
    void Start () {
        StartCoroutine(loadNewScene());
	}
	
	// Update is called once per frame
	void Update () {
        if (async.progress < 0.9f)
        {
            loadingBar.value = async.progress;
        }
        else
        {
            loadingText.SetActive(false);
            loadingBar.gameObject.SetActive(false);
            continueText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                async.allowSceneActivation = true;
            }
        }
        
	}

    IEnumerator loadNewScene()
    {
        async = SceneManager.LoadSceneAsync(level);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
