using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float deltaPosition;

    private Vector2 startPosition;
    private float position;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        position = Random.Range(0, 2 * Mathf.PI);   
    }

    private void Update()
    {
        position += Time.deltaTime;
        rb.MovePosition(startPosition + new Vector2(Mathf.Cos(position), Mathf.Sin(position)) * deltaPosition);
    }
}
