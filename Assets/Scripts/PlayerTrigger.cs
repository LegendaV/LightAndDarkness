using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private PlayerDeath _death;
    [SerializeField] private PlayerMovement _movement;

    private Dictionary<string, Action<Collider2D>> triggerAction = new Dictionary<string, Action<Collider2D>>();
    private Dictionary<string, Action<Collision2D>> collisionAction = new Dictionary<string, Action<Collision2D>>();
    private PlayerStats stats;
    private Rigidbody2D rb;

    private PlayerSound _playerSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        triggerAction["Energy"] = EnergyGet;
        triggerAction["Enemy"] = EnemyKill;
        triggerAction["Trap"] = TrapKill;
        triggerAction["DashEnergy"] = RestoreDash;
        stats = GetComponent<PlayerStats>();
        collisionAction["Enemy"] = EnemyDeath;
        collisionAction["Trap"] = TrapKill;

        _playerSound = GetComponent<PlayerSound>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerAction.ContainsKey(other.tag))
        {
            triggerAction[other.tag](other);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionAction.ContainsKey(collision.gameObject.tag))
        {
            collisionAction[collision.gameObject.tag](collision);
        }
    }

    private void EnemyDeath(Collision2D other)
    {
        _death.Death();
    }

    private void EnergyGet(Collider2D other)
    {
        stats.Energy += 1;
        _playerSound.PlayLootingSound();
        Destroy(other.gameObject);
    }

    private void EnemyKill(Collider2D other)
    {
        rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
    }

    private void TrapKill(Collider2D other)
    {
        _death.Death();
    }

    private void TrapKill(Collision2D other)
    {
        _death.Death();
    }

    private void RestoreDash(Collider2D other)
    {
        _movement.RestoreDash();
        _playerSound.PlayLootingSound();
    }
}
