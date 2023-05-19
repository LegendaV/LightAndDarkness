using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSound _playerSound;
    private bool _playingStepSound;
    private Random _random = new Random();
    
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    private float _groundRadius = 0.2f;
    
    private bool _onGround;
    private bool _isDashed = false;
    private bool _canUseDash = true;
    private Vector2 _dashDirection;

    private InputData _input;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PlayerStats _playerStats;

    private float _gravityScaleBeforeDash;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PutInput(InputData input)
    {
        _input = input;
    }

    private void FixedUpdate()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);
        if (_onGround)
        {
            _canUseDash = true;
        }
    }

    private void Update()
    {
        if (!_playerStats.InDialogue)
        {
            if (_isDashed && _playerStats.HasDash)
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
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
    }

    private void Move()
    {
        float moveX = _input.Direction.x;
        _animator.SetFloat("move x", Mathf.Abs(moveX));
        _animator.SetBool("on ground", _onGround);
        if (Mathf.Abs(moveX) > 0.1f && !_playingStepSound && _onGround)
            StartCoroutine(PlayStepSound());
        
        Vector2 movement = new Vector2(moveX * _playerStats.Speed, _rb.velocity.y);
        _rb.velocity = movement;

        if (moveX < 0)
        {
            _playerTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveX > 0)
        {
            _playerTransform.localScale = new Vector3(1, 1, 1);
        }
    }

    private IEnumerator PlayStepSound()
    {
        _playingStepSound = true;
        _playerSound.PlayStepSound();
        yield return new WaitForSeconds(0.25f);
        _playingStepSound = false;
    }

    private void Dash()
    {
        if ((!_input.IsDash || !_playerStats.HasDash || _input.Direction == Vector2.zero || !_canUseDash) && !_isDashed)
            return;

        if (!_isDashed)
        {
            _playerSound.PlayDashSound();
            _dashDirection = _input.Direction;
            StartCoroutine(ProcessDash());
            _canUseDash = false;
        }

        Vector2 movement = _dashDirection.normalized * _playerStats.DashForce;
        _rb.velocity = movement;
    }

    private IEnumerator ProcessDash()
    {
        _gravityScaleBeforeDash = _rb.gravityScale;
        _rb.gravityScale = 0;
        _isDashed = true;
        yield return new WaitForSeconds(0.2f);
        _isDashed = false;
        _dashDirection = Vector2.zero;
        _rb.gravityScale = _gravityScaleBeforeDash;
    }

    private void Jump()
    {
        if (!_input.IsJump)
            return;
    
        _playerSound.PlayDashSound();
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

    public void RestoreDash()
    {
        _canUseDash = true;
    }
}
