using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button buttonStart;
    public Button buttonQuit;
    
    void Start()
    {
        buttonStart.onClick.AddListener(StartGame);
        buttonQuit.onClick.AddListener(QuitApplication);
    }

    private void OnDestroy()
    {
        buttonStart.onClick.RemoveListener(StartGame);
        buttonQuit.onClick.RemoveListener(QuitApplication);
    }

    public void StartGame()
    {
        GameManager.instance.StartGame();
    }

    public void QuitApplication()
    {
        GameManager.instance.QuitApplication();
    }
}
