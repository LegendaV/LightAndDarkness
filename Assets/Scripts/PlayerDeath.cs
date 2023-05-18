using System.Collections;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    public void Death()
    {
        StartCoroutine(DisableControleCoroutine());
        transform.position = _playerStats.Checkpoint;
        _playerStats.LightPower = 1.5f;
    }

    IEnumerator DisableControleCoroutine()
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.Sleep();
        rb.WakeUp();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}