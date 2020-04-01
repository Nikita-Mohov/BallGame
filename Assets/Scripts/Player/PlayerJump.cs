using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private int _allJumpAmount;
    [SerializeField] private float _jumpForce;

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private GameObject _groundChecker;
    [SerializeField] private float _checkRadius;

    private Rigidbody2D _rigidbody2D;
    private int _jumpAmount;

    private bool _IsGround;

    private void Start()
    {
        _jumpAmount = _allJumpAmount;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _IsGround = Physics2D.OverlapCircle(_groundChecker.transform.position, _checkRadius, _whatIsGround);

        if (_IsGround == true)
            _jumpAmount = _allJumpAmount;

        if (Input.GetKeyDown(KeyCode.Space) && _jumpAmount > 0)
            Jump();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _jumpAmount--;
    }
}
