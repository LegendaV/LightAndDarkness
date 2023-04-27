using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerFading : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Light2D _light;
 
    private void Update()
    {
        _playerStats.LightPower = Mathf.Lerp(_playerStats.LightPower, 1f, Time.deltaTime / 15f);
        _light.pointLightOuterRadius = _playerStats.LightPower;
    }
}
