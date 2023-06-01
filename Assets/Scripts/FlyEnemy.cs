using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private Vector2 _startPosition;
    
    [SerializeField] private float _attackTime;

    private bool _isAttacking;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        var position = transform.position;
        transform.position = _isAttacking
            ? Vector2.Lerp(position, position + Vector3.down * _attackTime, 5 * Time.deltaTime)
            : Vector2.Lerp(transform.position, _startPosition, 8 * Time.deltaTime);
    }

    public void Attack()
    {
        StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        _isAttacking = true;

        yield return new WaitForSeconds(_attackTime);
        
        _isAttacking = false;
    }
}
