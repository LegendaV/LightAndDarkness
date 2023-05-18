using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerFading : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Light2D _light;
    [SerializeField] private PlayerDeath _playerDeath;

    private void Update()
    {
        if (_playerStats.NearCrystal)
        {
            _playerStats.LightPower = Mathf.Lerp(_playerStats.LightPower, 3f, Time.deltaTime);
            _light.pointLightOuterRadius = _playerStats.LightPower;
        }
        else if (!_playerStats.InDialogue)
        {
            _playerStats.LightPower = Mathf.Lerp(_playerStats.LightPower, 0.1f, Time.deltaTime / 12.5f);
            _light.pointLightOuterRadius = _playerStats.LightPower;
            if (_playerStats.LightPower < 0.6f)
                _playerDeath.Death();
        }
    }
}
