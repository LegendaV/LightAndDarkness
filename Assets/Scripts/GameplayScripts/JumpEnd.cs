using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class JumpEnd : MonoBehaviour
{
    [SerializeField]
    private FinalLight _light;
    [SerializeField]
    private EndGame _end;
    [SerializeField]
    private Light2D _playerLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerLight.intensity = 0;
            StartCoroutine(End());
        }
    }

    private IEnumerator End()
    {
        _light.Run();
        yield return new WaitForSeconds(3);
        _end.Finish(1);
    }
}
