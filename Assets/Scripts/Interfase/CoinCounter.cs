﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    private int _value = 0;
    [SerializeField] private  Text _counterText;

    private void Start()
    {
        _counterText.text = "Coins: " + _value;
    }

    public void AddCoin()
    {
        _value++;
        WriteValue();
    }

    private void WriteValue()
    {
        _counterText.text = "Coins: " + _value;
    }
}
