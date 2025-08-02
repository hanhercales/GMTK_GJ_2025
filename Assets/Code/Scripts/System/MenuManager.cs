using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("CurrentScene"))
            continueButton.interactable = false;
            
    }

    public void NewGame()
    {
        ChangeScene(1);
    }

    public void Continue()
    {
        ChangeScene(PlayerPrefs.GetInt("CurrentScene"));
    }

    private void ChangeScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
