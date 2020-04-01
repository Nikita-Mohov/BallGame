using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private LevelPart[] _levelParts;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private void Start()
    {
        SpawnObject();
    }

    private LevelPart GiveMember()
    {
        return _levelParts[Random.Range(0, _levelParts.Length)];
    }

    public void SpawnObject()
    {
        LevelPart spawnedLevelPart = Instantiate(GiveMember(), _spawnPoint.position, Quaternion.identity);
        spawnedLevelPart.Init(_player);
        spawnedLevelPart.Arrived += SpawnObject;
    }
}
