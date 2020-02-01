using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform[] _movingPoints;
    private float _speed;
    private int _currentPoint = 1;

    private bool _isArc = false;

    private void Start()
    {
        transform.position = _movingPoints[0].transform.position;
    }

    private void Update()
    {
        if (_isArc)
        {
            Transform target = _movingPoints[_currentPoint].transform;
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if(transform.position == target.position)
            {
                if(_currentPoint == 1)
                {
                    _currentPoint = 0;
                }
                else
                {
                    _currentPoint = 1;
                    _isArc = false;
                }
            }
        }
    }

    public void ArcToggle()
    {
        _isArc = true;
    }

    public void GetSpeed(float speed)
    {
        _speed = speed;
    }
}
