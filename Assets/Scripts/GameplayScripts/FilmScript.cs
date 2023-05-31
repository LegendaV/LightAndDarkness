using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FilmScript : MonoBehaviour
{
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera _camera;
    [SerializeField]
    private GameObject[] _firefly;
    [SerializeField]
    private int _fireflyVictoryCount;
    [SerializeField]
    private PlayerStats _playerStats;
    [SerializeField]
    private FinalLight _finalLight;
    [SerializeField]
    private GameObject[] _falseScene;
    [SerializeField]
    private EndGame _end;

    private bool _resetInput = false;
    private bool _filmStart = false;
    private bool _goodEnd = false;

    private void Update()
    {
        if (_resetInput)
        {
            if (_camera.m_Lens.OrthographicSize < 20)
            {
                _camera.m_Lens.OrthographicSize = Mathf.Min(20, _camera.m_Lens.OrthographicSize + 5 * Time.deltaTime);
            }
            Input.ResetInputAxes();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_filmStart)
        {
            _filmStart = true;
            _resetInput = true;
            if (_playerStats.Energy >= _fireflyVictoryCount)
            {
                _goodEnd = true;
            }
            _playerStats.Energy = 0;
            StartCoroutine(Film());
        }
    }

    private IEnumerator Film()
    {
        var deltaTime = 2f;
        foreach (var firefly in _firefly)
        {
            firefly.SetActive(true);
            yield return new WaitForSeconds(deltaTime);
            deltaTime /= 1.5f;
        }
        if (_goodEnd)
        {
            _finalLight.Blick();
            _finalLight.Run();
            yield return new WaitForSeconds(5);
            _resetInput = false;
            _end.Finish(0);
        }
        else
        {
            _finalLight.Blick();

            yield return new WaitForSeconds(5);
            deltaTime = 1;
            foreach (var firefly in _firefly.Reverse())
            {
                firefly.SetActive(false);
                yield return new WaitForSeconds(deltaTime);
                deltaTime /= 1.5f;
            }
            _resetInput = false;
            foreach (var obj in _falseScene)
            {
                obj.SetActive(true);
            }
        }
    }
}
