using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : OncomingObjects
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CoinCounter.AddCoin();
            Destroy(gameObject);
        }
    }
}
