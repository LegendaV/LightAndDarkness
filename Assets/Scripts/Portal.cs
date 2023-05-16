using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private Transform _position;
    [SerializeField]
    private PlayerStats _playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_playerStats.Energy > 0)
            {
                _playerStats.Energy--;
            }
            collision.gameObject.transform.position = _position.position;
        }
    }
}
