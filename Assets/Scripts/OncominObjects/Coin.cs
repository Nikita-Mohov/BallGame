using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCoinPick playerCoinPick = collision.GetComponent<PlayerCoinPick>();

        if(playerCoinPick != null)
        {
            playerCoinPick.Pick();
            Destroy(gameObject);
        }
    }
}
