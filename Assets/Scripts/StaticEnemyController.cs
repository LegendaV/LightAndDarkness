using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaticEnemyController : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private Vector2 startPos;
    [SerializeField] private float speed;
    [SerializeField] private float killDistance = 10;
    [SerializeField] private GameObject player;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        startPos = circleCollider.offset;
    }

    void FixedUpdate()
    {
        if (!player.IsDestroyed())
        {
            float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
            if (distanceToPlayer > killDistance)
            {
                ReturnStartPos();
            }
            else
            {
                KillPlayer();
            }
        }
        else
        {
            ReturnStartPos();
        }
    }

    void KillPlayer()
    {
        var dx = speed * Time.deltaTime;
        var dy = -speed * Time.deltaTime;
        if (Math.Abs(dx + circleCollider.offset.x) > killDistance)
        {
            dx = killDistance - circleCollider.offset.x;
        }
        if (player.transform.position.x < transform.position.x)
        {
            dx = -dx;
        }
        if (dy + circleCollider.offset.y < -startPos.y)
        {
            dy = -startPos.y - circleCollider.offset.y;
        }
        circleCollider.offset += new Vector2(dx, dy);
    }

    void ReturnStartPos()
    {
        if (circleCollider.offset != startPos)
        {
            var dx = speed * Time.deltaTime;
            var dy = speed * Time.deltaTime;
            if (Math.Abs(dx + circleCollider.offset.x) > startPos.x)
            {
                dx = startPos.x - circleCollider.offset.x;
            }
            if (startPos.x < transform.position.x)
            {
                dx = -dx;
            }
            if (dy + circleCollider.offset.y > startPos.y)
            {
                dy = startPos.y - circleCollider.offset.y;
            }
            circleCollider.offset += new Vector2(dx, dy);
        }
    }
}