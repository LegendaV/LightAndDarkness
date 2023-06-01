using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Random = System.Random;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string _startGameScene;
    [SerializeField]
    private GameObject _setMenu;

    [SerializeField] private AudioSource _menuAudio;
    [SerializeField] private AudioClip[] _clickSounds;
    private Random _random = new Random();

    private void PlayClickSound()
    {
        _menuAudio.PlayOneShot(_clickSounds[_random.Next(_clickSounds.Length)]);
    }
    
    public void StartGame()
    {
        PlayClickSound();
        Cursor.visible = false;
        LoadSystem.LoadScene(_startGameScene);
    }
    
    public void LoadGame()
    {
        PlayClickSound();
        Cursor.visible = false;
        LoadSystem.LoadSceneFromSave(_startGameScene, SaveSystem.LoadGame());
    }

    public void OpenSetMenu()
    {
        PlayClickSound();
        gameObject.SetActive(false);
        _setMenu.SetActive(true);
    }

    public void ExitGame()
    {
        PlayClickSound();
        Application.Quit();
    }
}