using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSooting : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    
    [SerializeField] private PlayerStats _stats;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float rechargeTime;

    private bool canShoot;

    private void Start()
    {
        _stats = GetComponent<PlayerStats>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && _stats.Energy > 0 && canShoot)
        {
            _stats.Energy -= 1;
            Vector2 direction;
            if (spriteRenderer.flipX)
                direction = new Vector2(-1, 0);
            else
                direction = new Vector2(1, 0);
            var bullet = Instantiate(_bullet, transform.position + new Vector3(direction.x, direction.y), transform.rotation);
            var script = bullet.GetComponent<Bullet>();
            script.SetDirection(direction);
            canShoot = false;
            StartCoroutine(CanShootCoroutine(rechargeTime));
        }
    }

    private IEnumerator CanShootCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canShoot = true;
    }
}
