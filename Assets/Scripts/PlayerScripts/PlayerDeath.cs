using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;

    public void Death()
    {
        _deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
