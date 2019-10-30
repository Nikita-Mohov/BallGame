using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private BarrierSpawner _barrierSpawner;

    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private GameObject[] _pointsOfCoinSpawn;
    private Vector2 _spawnPoint;

    private new float _timeBetweenSpawn;

    void Start()
    {
        _timeBetweenSpawn = _barrierSpawner.TimeBetweenSpawn - 0.2f;
        _timeToSpawn = _timeBetweenSpawn;
    }

    void Update()
    {
        if (_timeToSpawn <= 0)
        {
            _timeToSpawn = _timeBetweenSpawn;
            StartCoroutine(SpawnCheck());
        }
        else
        {
            _timeToSpawn -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnCheck()
    {
        int spawnCoins = Random.Range(1, 2);
        if (spawnCoins == 1)
        {
            if (_barrierSpawner.Spawnpoint == 2 || _barrierSpawner.Spawnpoint == 3)
                StartCoroutine(SpawnRaw());
            else
                StartCoroutine(SpawnArc());
        }
        else
        {
            yield return new WaitForSeconds(0.4f);
            _timeToSpawn = _timeBetweenSpawn;
        }
    }

    private IEnumerator SpawnRaw()
    {
        _spawnPoint = _pointsOfCoinSpawn[0].transform.position;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_coinTemplate, _spawnPoint, Quaternion.identity);
            if(i != 2)
            {
                yield return new WaitForSeconds(0.2f);
            }
        }
        _timeToSpawn = _timeBetweenSpawn;
    }

    private IEnumerator SpawnArc()
    {
        _spawnPoint = _pointsOfCoinSpawn[1].transform.position;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_coinTemplate, _spawnPoint, Quaternion.identity);
            if (i == 0)
            {
                _spawnPoint.y += 1;
                yield return new WaitForSeconds(0.2f);
            }
            else if (i == 1)
            {
                _spawnPoint.y -= 1;
                yield return new WaitForSeconds(0.2f);
            }
        }
        _timeToSpawn = _timeBetweenSpawn;
    }
}
