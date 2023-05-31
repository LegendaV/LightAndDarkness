using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FinalLight : MonoBehaviour
{
    [SerializeField]
    private Light2D _light;
    [SerializeField]
    private float _speed = 5;
    private int _blickState = 0;
    private bool _isRun;

    void Update()
    {
        if (_blickState == 1)
        {
            if (_light.pointLightOuterRadius > 5)
            {
                _light.pointLightOuterRadius = Mathf.Max(5, _light.pointLightOuterRadius - _speed / 2 * Time.deltaTime);
            }
            else
            {
                _light.pointLightOuterRadius = 10;
                _blickState = 2;
            }
        }
        else if (_blickState == 2)
        {
            if (_light.pointLightOuterRadius > 0)
            {
                _light.pointLightOuterRadius = Mathf.Max(0, _light.pointLightOuterRadius - _speed / 2 * Time.deltaTime);
            }
            else
            {
                _blickState = 0;
            }
        }
        else if (_isRun)
        {
            if (_light.pointLightOuterRadius < 100)
            {
                _light.pointLightOuterRadius += _speed * 2 * Time.deltaTime;
            }
            else
            {
                _isRun = false;
            }
        }
    }

    public void Run()
    {
        _isRun = true;
    }

    public void Blick()
    {
        _light.pointLightOuterRadius = 13;
        _blickState = 1;
    }
}
