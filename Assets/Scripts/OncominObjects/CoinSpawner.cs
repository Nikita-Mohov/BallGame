using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private ObjectsSpawner _objectsSpawner;
    [SerializeField] private CoinSpawnPoint _coinSpawnPoint;

    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private GameObject[] _pointsOfCoinSpawn;

    private int _numberOfCoin;
    private int _currentPoint = 0;
    private float _speedOfSpawnPoint;

    [SerializeField] private int _coinsQuantity;
    [SerializeField] private float _rowLength;
    private float _distanceBetweenCoins;
    public float DistanceBetweenCoins
    {
        get
        {
           return _distanceBetweenCoins;
        }
    }


    private void Start()
    {
        _distanceBetweenCoins = _rowLength / _coinsQuantity;
        _speedOfSpawnPoint = 2 * (_pointsOfCoinSpawn[1].transform.position.y - _pointsOfCoinSpawn[0].transform.position.y) / ( _distanceBetweenCoins / _coinTemplate.Speed * _coinsQuantity);
        _coinSpawnPoint.GetSpeed(_speedOfSpawnPoint);
    }

    public void SpawnSelection()
    {
        if(Random.Range(0, 2) == 1)
        {
            _coinSpawnPoint.ArcToggle();
        }
        _numberOfCoin = 0;
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        Coin coin = Instantiate(_coinTemplate, _coinSpawnPoint.transform.position, Quaternion.identity);
        _numberOfCoin++;
        foreach (Coin c in GameObject.FindObjectsOfType<Coin>())
        {
            if(_numberOfCoin  == _coinsQuantity)
            {
                if(c == coin)
                {
                    c.OnArrival += _objectsSpawner.SpawnObject;
                }
            }
            else
            {
                c.OnMovedAway += SpawnCoin;
            }
        }
    }
}
