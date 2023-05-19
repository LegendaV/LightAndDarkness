using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaveCheckpoint : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gameObject = collision.gameObject;
        if (gameObject.tag == "Crystal")
        {
            if (_playerStats.Checkpoint != (Vector2)gameObject.transform.position)
            {
                SaveSystem.SaveGame(SceneManager.GetActiveScene().name);
                var crystal = collision.gameObject.GetComponent<Crystal>();
                StartCoroutine(crystal.PlayCrystalSound());
            }
            _playerStats.Checkpoint = gameObject.transform.position;
            _playerStats.NearCrystal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var gameObject = collision.gameObject;
        if (gameObject.tag == "Crystal")
        {
            _playerStats.NearCrystal = false;
        }
    }
}
