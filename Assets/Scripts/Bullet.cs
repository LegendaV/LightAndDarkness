using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 5f;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed * 10);
        var position = new Vector2(transform.position.x, transform.position.y);
        rb.MovePosition(position + direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CircleCollider2D>());
        }
        Destroy(gameObject);
    }
}
