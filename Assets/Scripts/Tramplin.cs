using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Tramplin : MonoBehaviour
{
    [SerializeField] private AudioSource _tramplinAudio;
    [SerializeField] private AudioClip[] _tramplinSounds;
    private Random _random = new Random();

    [SerializeField]
    float force;
    [SerializeField]
    float maxJumpForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _tramplinAudio.PlayOneShot(_tramplinSounds[_random.Next(_tramplinSounds.Length)]);
            var player = collision.gameObject.GetComponent<Rigidbody2D>();
            float t;
            Vector3 v;
            transform.rotation.ToAngleAxis(out t, out v);
            player.velocity = new Vector2(-v.z * force, Mathf.Min(Mathf.Abs(player.velocity.y) * force, maxJumpForce));
        }
    }
}
