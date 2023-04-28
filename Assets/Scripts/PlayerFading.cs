using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerFading : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Light2D _light;
 
    private void Update()
    {
        _playerStats.LightPower = Mathf.Lerp(_playerStats.LightPower, 0.75f, Time.deltaTime / 12.5f);
        _light.pointLightOuterRadius = _playerStats.LightPower;
    }
}
