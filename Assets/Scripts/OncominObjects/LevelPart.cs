using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelPart : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    private float _countdown;
    private Player _player;

    private bool _isArrived = false;

    public event UnityAction Arrived;

    private void Start()
    {
        _countdown = _destroyTime;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (_player.transform.position.x >= gameObject.transform.position.x && !_isArrived)
        {
            Arrived?.Invoke();
            _isArrived = true;
        }

        if(_countdown > 0)
        {
            _countdown -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init (Player player)
    {
        _player = player;
    }
}
