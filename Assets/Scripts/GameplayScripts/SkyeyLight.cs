using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SkyeyLight : MonoBehaviour
{
    [SerializeField]
    private Light2D _light;
    [SerializeField]
    private float _loopTime;
    private float fadingSpeed;
    private bool isFading;
    private float intensityMax;

    private void Start()
    {
        intensityMax = _light.intensity;
        fadingSpeed = intensityMax / _loopTime;
        isFading = true;
    }

    private void FixedUpdate()
    {
        if (isFading)
        {
            _light.intensity = Mathf.Max(_light.intensity - fadingSpeed * Time.deltaTime, 0);
            isFading = _light.intensity > 0;
        }
        else
        {
            _light.intensity = Mathf.Min(_light.intensity + fadingSpeed * Time.deltaTime, intensityMax);
            isFading = _light.intensity >= intensityMax;
        }

    }
}
