using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudio;
    [SerializeField] private AudioClip[] _dashSounds;
    [SerializeField] private AudioClip[] _stepSounds;
    [SerializeField] private AudioClip[] _shootingSounds;
    [SerializeField] private AudioClip[] _lootingSounds;
    [SerializeField] private AudioClip[] _deathSounds;

    private Random _random = new Random();

    public void PlayDashSound()
    {
        PlayRandomSound(_dashSounds);
    }
    
    public void PlayStepSound()
    {
        PlayRandomSound(_stepSounds);
    }
    
    public void PlayShootingSound()
    {
        PlayRandomSound(_shootingSounds);
    }
    
    public void PlayLootingSound()
    {
        PlayRandomSound(_lootingSounds);
    }
    
    public void PlayDeathSound()
    {
        PlayRandomSound(_deathSounds);
    }

    private void PlayRandomSound(AudioClip[] clips) => _playerAudio.PlayOneShot(GetRandomSound(clips));

    private AudioClip GetRandomSound(AudioClip[] clips) => clips[_random.Next(clips.Length)];
}
