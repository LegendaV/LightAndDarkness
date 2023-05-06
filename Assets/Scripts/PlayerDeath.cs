using System.Collections;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    public void Death()
    {
        DisableControleCoroutine();
        transform.position = _playerStats.Checkpoint;
        _playerStats.LightPower = 1.5f;
    }

    IEnumerable DisableControleCoroutine()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.Sleep();
        yield return new WaitForSeconds(5);
        rb.WakeUp();
    }
}
