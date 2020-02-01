using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OncomingObjects : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    private GameObject _arrivalPoint;
    protected CoinSpawnPoint _spawnPoint;
    protected CoinSpawner _coinSpawner;

    private bool _isArrival;

    public event UnityAction OnArrival;
    public float Speed
    {
        get
        {
            return _speed;
        }
    }

    private void Start()
    {
        _isArrival = false;
        _arrivalPoint = GameObject.FindGameObjectWithTag("ArrivalPoint");
        _spawnPoint = GameObject.FindObjectOfType<CoinSpawnPoint>();
        _coinSpawner = GameObject.FindObjectOfType<CoinSpawner>();

        Invoke("Destroy", _destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (_arrivalPoint.transform.position.x >= gameObject.transform.position.x && !_isArrival)
        {
            if(OnArrival != null)
            {
                OnArrival();
                _isArrival = true;
            }
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
