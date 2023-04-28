using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    public void Death()
    {
        transform.position = _playerStats.Checkpoint;
        _playerStats.LightPower = 1.5f;
    }
}
