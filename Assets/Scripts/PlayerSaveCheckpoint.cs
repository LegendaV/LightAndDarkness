using UnityEngine;


public class PlayerSaveCheckpoint : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gameObject = collision.gameObject;
        if (gameObject.tag == "Crystal")
        {
            _playerStats.Checkpoint = gameObject.transform.position;
            _playerStats.LightPower = Mathf.Lerp(_playerStats.LightPower, 3f, Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var gameObject = collision.gameObject;
        if (gameObject.tag == "Crystal")
        {
            _playerStats.LightPower = Mathf.Lerp(_playerStats.LightPower, 3f, Time.deltaTime);
        }
    }
}
