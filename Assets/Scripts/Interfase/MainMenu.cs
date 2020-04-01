using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _authors;

    private void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    private void ToggleAuthors()
    {
        bool state = _authors.GetBool("IsOpen");
        _authors.SetBool("IsOpen", !state);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
