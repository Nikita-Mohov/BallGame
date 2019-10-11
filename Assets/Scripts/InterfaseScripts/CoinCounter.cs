using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static int _value = 0;
    private static Text _counterText;

    private void Start()
    {
        _counterText = GetComponent<Text>();
        _counterText.text = "Coins: " + _value;
    }

    public static void AddCoin()
    {
        _value++;
        WriteValue();
    }

    public static void WriteValue()
    {
        _counterText.text = "Coins: " + _value;
    }
}
