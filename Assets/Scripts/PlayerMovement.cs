using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    private float _groundRadius = 0.2f;
    
    private bool _onGround;
    private bool _isDashed = false;
    private Vector2 _dashDirection;

    private InputData _input;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerStats _playerStats;

    public void PutInput(InputData input)
    {
        _input = input;
    }

    private void FixedUpdate()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);
    }

    private void Update()
    {
        if (_isDashed)
        {
            Dash();
            return;
        }

        Move();
        if (_onGround)
            Jump();
        else
            Dash();
    }

    private void Move()
    {
        float moveX = _input.Direction.x;
        Vector2 movement = new Vector2(moveX * _playerStats.Speed, _rb.velocity.y);
        _rb.velocity = movement;

        if (moveX < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (moveX > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void Dash()
    {
        if ((!_input.IsDash || _input.Direction == Vector2.zero) && !_isDashed)
            return;

        if (!_isDashed)
        {
            _dashDirection = _input.Direction;
            StartCoroutine(ProcessDash());
        }

        Vector2 movement = _dashDirection.normalized * _playerStats.DashForce;
        _rb.velocity = movement;
    }

    private IEnumerator ProcessDash()
    {
        _isDashed = true;
        yield return new WaitForSeconds(0.2f);
        _isDashed = false;
        _dashDirection = Vector2.zero;
    }

    private void Jump()
    {
        if (!_input.IsJump)
            return;
    
        _rb.AddForce(new Vector2(0f, _playerStats.JumpForce), ForceMode2D.Impulse);
        _onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CapsuleCollider2D>());
        }
    }
}
