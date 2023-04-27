using System;
using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _dashForce;

    [SerializeField] private Transform _groundCheck;
    private float _groundRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private Vector2 _direction;
    private bool _jump;
    private bool _dash;

    private bool _onGround = true;
    private bool _isDash = false;
    private Vector2 _dashDirection = new Vector2(0, 0);

    public void SetDirection(InputData input)
    {
        _direction = input.Direction;
        _jump = input.Jump;
        _dash = input.Dash;
    }

    private void FixedUpdate()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);
    }

    private void Update()
    {
        if (!_isDash)
        {
            _rb.velocity = new Vector2(_speed * _direction.x, _rb.velocity.y);
        }

        if (_onGround && _jump)
        {
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        } 
        
        if (_isDash)
        {
            _rb.velocity = _dashForce * _dashDirection;
        }

        if (!_onGround && !_isDash && _dash)
        {
            _rb.velocity = _dashForce * _direction.normalized;
            _dashDirection = _direction.normalized;
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        _isDash = true;
        yield return new WaitForSeconds(0.15f);
        _isDash = false;
        _dashDirection = new Vector2(0, 0);
    }
}
