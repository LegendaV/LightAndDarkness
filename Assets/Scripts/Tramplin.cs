using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramplin : MonoBehaviour
{
    [SerializeField]
    float force;
    [SerializeField]
    float maxJumpForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<Rigidbody2D>();
            float t;
            Vector3 v;
            transform.rotation.ToAngleAxis(out t, out v);
            player.velocity = new Vector2(-v.z * force, Mathf.Min(Mathf.Abs(player.velocity.y) * force, maxJumpForce));
        }
    }
}
