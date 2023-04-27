using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private int currentDirection = 1;
    public float Speed = 5;
    [SerializeField]
    private float distanceX = 1;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x <= startPos.x - distanceX && currentDirection == -1)
            || (transform.position.x >= startPos.x + distanceX && currentDirection == 1)
            || rigidbody.velocity.x == 0)
        {
            ChangeDirection();
        }
        rigidbody.velocity = new Vector2(Speed * currentDirection, 0);
        transform.localScale = new Vector2(1.5f * currentDirection, 1.5f);
    }

    private void ChangeDirection()
    {
        currentDirection *= -1;
    }
}