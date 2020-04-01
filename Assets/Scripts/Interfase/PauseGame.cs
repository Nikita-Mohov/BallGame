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
            PauseSwitch();
        }
    }

    private void PauseSwitch()
    {
        _isGamePaused = !_isGamePaused;
        if (_isGamePaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        _pauseMenu.SetActive(_isGamePaused);
    }

    private void MainMenu()
    {
        PauseSwitch();
        SceneManager.LoadScene(0);
    }
}
