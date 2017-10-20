using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMenu : MonoBehaviour {

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void ButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
