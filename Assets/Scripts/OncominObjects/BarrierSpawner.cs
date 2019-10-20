using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    public float TimeBetweenSpawn { get => _timeBetweenSpawn; }
    public int Spawnpoint { get => _spawnpoint; }

    [SerializeField] private GameObject[] _barriers;
    [SerializeField] private GameObject[] _pointsOfBarriersSpawn;

    [SerializeField] private float _timeBetweenSpawn;
    private float _timeToSpawn;

    private int _spawnpoint;
    private int _tipeOfBarrier;

    private bool _IsSpawned;

    private void Start()
    {
        _IsSpawned = false;
        _timeToSpawn = _timeBetweenSpawn;
        _spawnpoint = Random.Range(0, _pointsOfBarriersSpawn.Length);
    }

    private void Update()
    {
        if (_timeToSpawn <= 0 && !_IsSpawned)
        {
            _IsSpawned = true;
            _timeToSpawn = _timeBetweenSpawn;
            StartCoroutine(SpawnBarrier());
        }
        else if(!_IsSpawned)
            _timeToSpawn -= Time.deltaTime;        
    }

    private IEnumerator SpawnBarrier()
    {
        _tipeOfBarrier = Random.Range(0, _barriers.Length);
        Instantiate(_barriers[_tipeOfBarrier], _pointsOfBarriersSpawn[_spawnpoint].transform.position, _pointsOfBarriersSpawn[_spawnpoint].transform.rotation);
        _spawnpoint = Random.Range(0, _pointsOfBarriersSpawn.Length);
        yield return new WaitForSeconds(0.2f);
        _IsSpawned = false;
    }
}
