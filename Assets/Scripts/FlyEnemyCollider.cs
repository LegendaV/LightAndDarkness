using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyCollider : MonoBehaviour
{
    private FlyEnemy _script;

    private void Start()
    {
        _script = GetComponentInParent<FlyEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _script.Attack();
        }
    }
}
