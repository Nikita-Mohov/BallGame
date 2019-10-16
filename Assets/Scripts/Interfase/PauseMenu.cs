using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private bool _gameIsPaused = false;

    private void Start()
    {
        _pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    protected void Pause()
    {
        _gameIsPaused = true;
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
    }

    public void MainMenu()
    {
        _gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        _gameIsPaused = false;
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }
}
