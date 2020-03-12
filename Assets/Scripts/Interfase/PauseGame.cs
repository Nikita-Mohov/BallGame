using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private bool _isGamePaused = false;

    private void Start()
    {
        _pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
                Resume();
            else
                Pause();
        }
    }

    protected void Pause()
    {
        _isGamePaused = true;
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
    }

    public void MainMenu()
    {
        _isGamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        _isGamePaused = false;
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }
}
