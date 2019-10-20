using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private BarrierSpawner _barrierSpawner;

    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private GameObject[] _pointsOfCoinSpawn;

    private float _timeBetweenSpawn;
    private float _timeToSpawn;

    private bool _IsSpawned;

    void Start()
    {
        _IsSpawned = false;
        _timeBetweenSpawn = _barrierSpawner.TimeBetweenSpawn - 0.2f;
        _timeToSpawn = _timeBetweenSpawn;
    }

    void Update()
    {
        if (_timeToSpawn <= 0 && !_IsSpawned)
        {
            _IsSpawned = true;
            _timeToSpawn = _timeBetweenSpawn;
            StartCoroutine(SpawnCoin());
        }
        else if(!_IsSpawned)
            _timeToSpawn -= Time.deltaTime;
    }

    private IEnumerator SpawnCoin()
    {
        int coinspawnpoint;
        int spawnCoins = Random.Range(0, 3);
        if (spawnCoins == 1)
        {
            if (_barrierSpawner.Spawnpoint == 2 || _barrierSpawner.Spawnpoint == 3)
                coinspawnpoint = 0;
            else
                coinspawnpoint = 1;
            Instantiate(_coinTemplate, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
            yield return new WaitForSeconds(0.2f);

            if (coinspawnpoint == 1)
                coinspawnpoint = 2;
            Instantiate(_coinTemplate, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
            yield return new WaitForSeconds(0.2f);

            if (coinspawnpoint == 2)
                coinspawnpoint = 1;
            Instantiate(_coinTemplate, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
        }
        else
            yield return new WaitForSeconds(0.4f);
        _IsSpawned = false;
    }
}
