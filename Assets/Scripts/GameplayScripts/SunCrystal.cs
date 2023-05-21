using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SunCrystal : MonoBehaviour
{
    [SerializeField] GameObject _crystalDestroy;
    [SerializeField] PlayerStats _playerStats;

    void Start()
    {
        if (_playerStats.SunCrystalProgress > 0)
        {
            _crystalDestroy.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _playerStats.SunCrystalProgress == 0)
        {
            _playerStats.SunCrystalProgress = 1;
            _crystalDestroy.SetActive(false);
        }
    }
}
