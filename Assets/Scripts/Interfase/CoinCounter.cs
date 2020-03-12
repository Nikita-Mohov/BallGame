using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text _counterText;

    private int _valueView = 0;

    private void Start()
    {
        WriteValue();
    }

    public void AddCoin()
    {
        _valueView++;
        WriteValue();
    }

    private void WriteValue()
    {
        _counterText.text = "Coins: " + _valueView;
    }
}
