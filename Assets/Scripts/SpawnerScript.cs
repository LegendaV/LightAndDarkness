using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public bool IsDestroyed { get; set; } = false;

    private GameObject spawnObject;

    void Start()
    {
        spawnObject = GetComponentsInChildren<Transform>(true)[1].gameObject;
        if (IsDestroyed)
        {
            Destroy(spawnObject);
        }
    }

    void Update()
    {
        if (!IsDestroyed && spawnObject.IsDestroyed())
        {
            IsDestroyed = true;
        }
    }
}
