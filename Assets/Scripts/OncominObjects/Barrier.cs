using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : OncomingObjects
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDeath player = collision.GetComponent<PlayerDeath>();
        if (player != null)
        {
            player.Death();
        }
    }
}
