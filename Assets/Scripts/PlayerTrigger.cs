using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Dictionary<string, Action<Collider2D>> triggerAction = new Dictionary<string, Action<Collider2D>>();
    private PlayerStats stats;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        triggerAction["Energy"] = EnergyGet;
        triggerAction["Enemy"] = EnemyKill;
        stats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerAction.ContainsKey(other.tag))
        {
            triggerAction[other.tag](other);
        }
    }

    private void EnergyGet(Collider2D other)
    {
        stats.Energy += 1;
        Destroy(other.gameObject);
    }

    private void EnemyKill(Collider2D other)
    {
        rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
    }
}
