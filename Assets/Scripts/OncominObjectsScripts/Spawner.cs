using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject[] _barriers;
    [SerializeField] private GameObject[] _pointsOfBarriersSpawn;
    [SerializeField] private GameObject[] _pointsOfCoinSpawn;

    [SerializeField] private float _timeBetweenSpawn;
    private float _timeToSpawn;


    private void Start()
    {
        _timeToSpawn = _timeBetweenSpawn;
    }

    private void Update()
    {
        if (_timeToSpawn > 0)
        {
            _timeToSpawn -= 1 * Time.deltaTime;
        }
        else
        {
            StartCoroutine(Spawn());
            _timeToSpawn = _timeBetweenSpawn;
        }
    }

    private IEnumerator Spawn()
    {
        int spawnpoint = Random.Range(0, _pointsOfBarriersSpawn.Length);
        int tipeofbarrier = Random.Range(0, _barriers.Length);
        int coinspawnpoint;
        int coinspawn = Random.Range(0, 3);

        if(coinspawn == 1)
        {
            if (spawnpoint == 2 || spawnpoint == 3)
            {
                coinspawnpoint = 0;
                Instantiate(_coin, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
            }
            else
            {
                coinspawnpoint = 1;
                Instantiate(_coin, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
            }
            yield return new WaitForSeconds(0.2f);

            Instantiate(_barriers[tipeofbarrier], _pointsOfBarriersSpawn[spawnpoint].transform.position, _pointsOfBarriersSpawn[spawnpoint].transform.rotation);
            if (coinspawnpoint == 1)
                coinspawnpoint = 2;
            Instantiate(_coin, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
            yield return new WaitForSeconds(0.2f);

            if (coinspawnpoint == 2)
                coinspawnpoint = 1;
            Instantiate(_coin, _pointsOfCoinSpawn[coinspawnpoint].transform.position, _pointsOfCoinSpawn[coinspawnpoint].transform.rotation);
        }
        else
        {
            Instantiate(_barriers[tipeofbarrier], _pointsOfBarriersSpawn[spawnpoint].transform.position, _pointsOfBarriersSpawn[spawnpoint].transform.rotation);
        }
        
    }
}
