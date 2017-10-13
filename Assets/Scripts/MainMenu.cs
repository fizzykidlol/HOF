using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour {

    public GameObject optionsPanel;
    public GameObject confirmQuitPanel;
    public GameObject pauseMenuPanel;
    public GameObject analyticsPanel;
    private bool options;
    private bool confirmQuit;

    public Button StartButton;
    public Button optionsButton;
    public Button quitButton;
    public Button quitYesButton;
    public Button quitNoButton;
    public Button analyticsYesButton;
    public Button analyticsNoButton;

    private void Start()
    {
        StartButton.onClick.AddListener(delegate { startButtonPressed(); });
        optionsButton.onClick.AddListener(delegate { optionsButtonPressed(); });
        quitButton.onClick.AddListener(delegate { quitButtonPressed(); });
        quitYesButton.onClick.AddListener(delegate { confirmQuitButton(); });
        quitNoButton.onClick.AddListener(delegate { exitQuitConfirmation(); });
        analyticsYesButton.onClick.AddListener(delegate { analyticsYes(); });
        analyticsNoButton.onClick.AddListener(delegate { analyticsNo(); });
    }

    public void startButtonPressed()
    {
        analyticsPanel.SetActive(true);
    }


    public void optionsButtonPressed()
    {
        optionsPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        options = true;

    }

    public void quitButtonPressed()
    {
        confirmQuitPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        confirmQuit = true;

    }

    public void confirmQuitButton()
    {
        SceneManager.LoadScene(4);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (options)
            {
                exitOptions();
            }
            else if (confirmQuit)
            {
                exitQuitConfirmation();
            }
        }
    }

    public void analyticsYes()
    {
        analyticsManager.instance.analyticsOn = true;
        Analytics.enabled = true;
        Analytics.CustomEvent("Player Started Game");
        SceneManager.LoadScene(1);
    }

    public void analyticsNo()
    {
        analyticsManager.instance.analyticsOn = false;
        Analytics.enabled = false;
        SceneManager.LoadScene(1);
    }

    public void exitOptions()
    {
        optionsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        options = false;
    }

    public void exitQuitConfirmation()
    {
        confirmQuitPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        confirmQuit = false;
    }
}
