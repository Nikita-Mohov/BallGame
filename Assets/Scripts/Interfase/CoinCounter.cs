using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text _valueView;

    private int _value = 0;

    private void Start()
    {
        WriteValue();
    }

    public void AddCoin()
    {
        _value++;
        WriteValue();
    }

    private void WriteValue()
    {
        _valueView.text = "Coins: " + _value;
    }
}
