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
        }
    }
}
