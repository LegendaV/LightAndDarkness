using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnergySpawner : MonoBehaviour
{
    public bool IsUnpicked { get; set; } = true;
    [SerializeField]
    GameObject _energy;

    private GameObject energy = null;

    void Start()
    {
        if (IsUnpicked)
        {
            energy = Instantiate(_energy, transform.position, transform.rotation);
            energy.transform.SetParent(gameObject.transform);
        }
    }

    void Update()
    {
        if (IsUnpicked && energy.IsDestroyed())
        {
            IsUnpicked = false;
        }
    }
}
