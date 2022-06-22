using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUiHandler : MonoBehaviour {

    public TMP_InputField register_username;
    public static MenuUiHandler mm;
    public string playerName;

    private void Awake()
    {
        if (mm != null)
        {
            Destroy(gameObject);
            return;
        }
        mm = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeName()
    {
        mm.playerName = register_username.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        //save highscore 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}