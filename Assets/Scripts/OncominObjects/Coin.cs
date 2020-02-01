using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : OncomingObjects
{
    private bool _isMovedAway;

    public event UnityAction OnMovedAway;

    private void FixedUpdate()
    {
        if (_spawnPoint.transform.position.x - gameObject.transform.position.x >=  _coinSpawner.DistanceBetweenCoins  && !_isMovedAway)
        {
            if(OnMovedAway != null)
            {
                OnMovedAway();
            }
            _isMovedAway = true;
        }
    }

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
