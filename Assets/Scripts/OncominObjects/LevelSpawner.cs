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

    public void SpawnObject()
    {
        LevelPart spawnedLevelPart = Instantiate(_levelParts[Random.Range(0, _levelParts.Length)], _spawnPoint.position, Quaternion.identity);
        spawnedLevelPart.Init(_player);
        foreach (LevelPart lp in GameObject.FindObjectsOfType<LevelPart>())
        {
            lp.Arrived += SpawnObject;
        }
    }
}
