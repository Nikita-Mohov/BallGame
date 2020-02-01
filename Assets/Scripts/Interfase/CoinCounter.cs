using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text _counterText;

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
        _counterText.text = "Coins: " + _value;
    }
}
