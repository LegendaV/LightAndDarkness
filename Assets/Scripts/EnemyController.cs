using System.Collections;
using UnityEngine;
using Random = System.Random;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private AudioSource _enemyAudio;
    [SerializeField] private AudioClip[] _enemySounds;
    private bool _playingSound;
    private Random _random = new Random();

    private Rigidbody2D _rb;
    private int currentDirection = 1;
    public float Speed = 5;
    [SerializeField]
    private float _distanceX = 1;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_playingSound)
            StartCoroutine(PlaySound());
        
        if ((transform.position.x <= startPos.x - _distanceX && currentDirection == -1)
            || (transform.position.x >= startPos.x + _distanceX && currentDirection == 1)
            || _rb.velocity.x == 0)
        {
            ChangeDirection();
        }
        _rb.velocity = new Vector2(Speed * currentDirection, 0);
        transform.localScale = new Vector2(1.5f * currentDirection, 1.5f);
    }

    private IEnumerator PlaySound()
    {
        _playingSound = true;
        _enemyAudio.PlayOneShot(_enemySounds[_random.Next(_enemySounds.Length)]);
        yield return new WaitForSeconds(0.75f);
        _playingSound = false;
    }

    private void ChangeDirection()
    {
        currentDirection *= -1;
    }

    public void SetStats(float speed, float distanceX)
    {
        Speed = speed;
        _distanceX = distanceX;
    }
}