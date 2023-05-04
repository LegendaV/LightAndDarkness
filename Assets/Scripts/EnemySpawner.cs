using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool IsAlive { get; set; } = true;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _distanceX;
    [SerializeField]
    private float _killDistance;

    private GameObject enemy = null;

    void Start()
    {
        if (IsAlive)
        {
            enemy = Instantiate(_enemy, transform.position, transform.rotation);
            enemy.transform.SetParent(gameObject.transform);
            if (enemy.TryGetComponent<EnemyController>(out var enemyController))
            {
                enemyController.SetStats(_speed, _distanceX);
            }
            else if (enemy.TryGetComponent<StaticEnemyController>(out var staticEnemyController))
            {
                staticEnemyController.SetStats(_speed, _killDistance);
            }
        }
    }

    private void Update()
    {
        if (IsAlive && enemy.IsDestroyed())
        {
            IsAlive = false;
        }
    }
}
