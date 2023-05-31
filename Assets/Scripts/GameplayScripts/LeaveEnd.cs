using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LeaveEnd : MonoBehaviour
{
    [SerializeField]
    private EndGame _end;
    [SerializeField]
    private Light2D _light;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _light.intensity = 0;
            _end.Finish(2);
        }
    }
}
