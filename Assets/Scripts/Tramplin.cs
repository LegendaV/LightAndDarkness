using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramplin : MonoBehaviour
{
    [SerializeField]
    float force;
    [SerializeField]
    float maxJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
