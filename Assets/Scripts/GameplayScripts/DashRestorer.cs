using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashRestorer : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    private bool _playerIn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerIn = false;
        }
    }

    void Update()
    {
        if (_playerIn)
        {
            _playerMovement.RestoreDash();
        }
    }
}
