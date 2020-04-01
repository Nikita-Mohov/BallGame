using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinPick : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;

    public void Pick()
    {
        _coinCounter.AddCoin();
    }
}
