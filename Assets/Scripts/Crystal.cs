using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Crystal : MonoBehaviour
{
    [SerializeField] private AudioClip[] _crystalSounds;
    [SerializeField] private AudioSource _crystalAudio;
    private bool _playingSounds;
    private Random _random = new Random();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_playingSounds)
        {
            StartCoroutine(PlayCrystalSound());
        }
    }

    private IEnumerator PlayCrystalSound()
    {
        _playingSounds = true;

        _crystalAudio.PlayOneShot(_crystalSounds[_random.Next(_crystalSounds.Length)]);
        
        yield return new WaitForSeconds(1f);
        
        _playingSounds = false;
    }
}
