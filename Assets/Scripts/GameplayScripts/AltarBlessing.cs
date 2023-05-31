using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarBlessing : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _activeAfterDash;
    [SerializeField]
    private PlayerStats _playerStats;

    private void Start()
    {
        foreach (var obj in _activeAfterDash)
        {
            obj.SetActive(false);
        }
        if (_playerStats.SkyeyFireflyProgress == 2)
        {
            foreach (var obj in _activeAfterDash)
            {
                obj.SetActive(true);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _playerStats.SkyeyFireflyProgress == 1)
        {
            _playerStats.SkyeyFireflyProgress = 2;
            _playerStats.HasDash = true;
            foreach (var obj in _activeAfterDash)
            {
                obj.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
