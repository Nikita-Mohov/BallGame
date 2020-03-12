using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelPart : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    private Player _player;

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
        _player = GameObject.FindObjectOfType<Player>();

        Invoke("Destroy", _destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (_player.transform.position.x >= gameObject.transform.position.x && !_isArrival)
        {
            OnArrival?.Invoke();
            _isArrival = true;
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
