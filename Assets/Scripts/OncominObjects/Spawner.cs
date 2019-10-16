using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _barriers;
    [SerializeField] private GameObject[] _pointsOfBarriersSpawn;
    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private GameObject[] _pointsOfCoinSpawn;

    [SerializeField] private float _timeBetweenSpawn;
    private float _timeToSpawn;

    private int _spawnpoint;
    private int _tipeOfBarrier;

    private void Start()
    {
        _timeToSpawn = _timeBetweenSpawn;
    }

    private void Update()
    {
        if (_timeToSpawn <= 0)
        {
            _timeToSpawn = _timeBetweenSpawn;
            StartCoroutine(SpawnCoin());
        }
        else
            _timeToSpawn -= Time.deltaTime;        
    }

    private void SpawnBarrier()
    {
            _tipeOfBarrier = Random.Range(0, _barriers.Length);
            Instantiate(_barriers[_tipeOfBarrier], _pointsOfBarriersSpawn[_spawnpoint].transform.position, _pointsOfBarriersSpawn[_spawnpoint].transform.rotation);
    }

    private IEnumerator SpawnCoin()
    {
        _spawnpoint = Random.Range(0, _pointsOfBarriersSpawn.Length);
        int coinspawnpoint;
        int spawnCoins = Random.Range(0, 3);
        if (spawnCoins == 1)
        {
            if (_spawnpoint == 2 || _spawnpoint == 3)
                coinspawnpoint = 0;
            else
                coinspawnpoint = 1;
            Instantiate(_coinTemplate, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
            yield return new WaitForSeconds(0.2f);

            SpawnBarrier();
            if (coinspawnpoint == 1)
                coinspawnpoint = 2;
            Instantiate(_coinTemplate, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
            yield return new WaitForSeconds(0.2f);

            if (coinspawnpoint == 2)
                coinspawnpoint = 1;
            Instantiate(_coinTemplate, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
        }
        else
            SpawnBarrier();
    }
}
