using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;

    [SerializeField] private GameObject[] _barriers;
    [SerializeField] private GameObject[] _pointsOfBarriersSpawn;

    [SerializeField] private int _chanceOfSpawnCoins;

    private void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        if(_chanceOfSpawnCoins >= Random.Range(1, 11))
        {
            _coinSpawner.SpawnSelection();
        }
        else
        {
            Instantiate(_barriers[Random.Range(0, _barriers.Length)], _pointsOfBarriersSpawn[Random.Range(0, _pointsOfBarriersSpawn.Length)].transform.position, Quaternion.identity);

            foreach (Barrier b in GameObject.FindObjectsOfType<Barrier>())
            {
                b.OnArrival += SpawnObject;
            }
        }
    }
}
