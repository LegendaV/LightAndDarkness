using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrystalRevampActivator : MonoBehaviour
{
    [SerializeField] PlayerStats _playerStats;
    [SerializeField] GameObject[] _activate;
    [SerializeField] GameObject[] _deactivate;

    void Start()
    {
        if (_playerStats.SunCrystalProgress == 2)
        {
            _activate.ToList().ForEach(o => o.SetActive(true));
            _deactivate.ToList().ForEach(o => o.SetActive(false));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _playerStats.SunCrystalProgress == 1)
        {
            _playerStats.SunCrystalProgress = 2;
            Start();
        }
    }
}
