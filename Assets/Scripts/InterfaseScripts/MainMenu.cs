﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator Authors;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowAuthors()
    {
        bool state = Authors.GetBool("IsOpen");
        Authors.SetBool("IsOpen", !state);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
