using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private int currentDirection = 1;
    public float Speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Speed * currentDirection, 0);
        transform.localScale = new Vector2(1.5f * currentDirection, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        currentDirection *= -1;
    }
}
