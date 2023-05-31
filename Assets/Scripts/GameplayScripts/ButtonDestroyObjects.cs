using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroyObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _destroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (var obj in _destroy)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
        }
    }
}
