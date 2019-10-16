﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingObjects : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    private void Start()
    {
        Invoke("Destroy", _destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}