﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [System.Obsolete]
    public void startGame(string sceneName)
    {
        Application.LoadLevel(sceneName); 
    }
}
