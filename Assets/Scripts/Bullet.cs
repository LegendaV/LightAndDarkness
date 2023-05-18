using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] Rigidbody2D _rb;
    private Vector2 _direction;   
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * _speed * 10);
        var position = new Vector2(transform.position.x, transform.position.y);
        _rb.MovePosition(position + _direction * _speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Crystal")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CircleCollider2D>());
        }
        Destroy(gameObject);
    }
}
