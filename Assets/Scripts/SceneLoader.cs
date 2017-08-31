using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    public Text loadingText;
    public string level;

	// Use this for initialization
	void Start () {
        StartCoroutine(loadNewScene());
	}
	
	// Update is called once per frame
	void Update () {
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g,
            loadingText.color.b, Mathf.PingPong(Time.time, 1));
	}

    IEnumerator loadNewScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(level);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
