using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : OncomingObjects
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
