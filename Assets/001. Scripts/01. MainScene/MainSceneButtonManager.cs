﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButtonManager : MonoBehaviour {

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void EndButton()
    {
        Application.Quit();
    }
}