using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _authors;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ToggleAuthors()
    {
        bool state = _authors.GetBool("IsOpen");
        _authors.SetBool("IsOpen", !state);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
