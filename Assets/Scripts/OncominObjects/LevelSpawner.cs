using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelParts;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        Instantiate(_levelParts[Random.Range(0, _levelParts.Length)], _spawnPoint.position, Quaternion.identity);

        foreach (LevelPart lp in GameObject.FindObjectsOfType<LevelPart>())
        {
            lp.OnArrival += SpawnObject;
        }
    }
}
