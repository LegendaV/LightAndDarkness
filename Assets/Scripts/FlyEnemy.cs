using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    [SerializeField] private float _distance = 20f;
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, _distance);
        if (hit.collider is not null && hit.collider.CompareTag("Player"))
        {
            transform.position = Vector2.Lerp(
                transform.position, 
                hit.collider.transform.position, 
                Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.Lerp(
                transform.position, 
                _startPosition, 
                Time.deltaTime);
        }
    }
}
