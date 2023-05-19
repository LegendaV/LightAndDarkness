using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;


public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip[] _deathSounds;
    private Random _random = new Random();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            var audio = Instantiate(_audio);
            audio.PlayOneShot(_deathSounds[_random.Next(_deathSounds.Length)]);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            var audio = Instantiate(_audio);
            audio.PlayOneShot(_deathSounds[_random.Next(_deathSounds.Length)]);
            Destroy(gameObject);
        }
    }
}