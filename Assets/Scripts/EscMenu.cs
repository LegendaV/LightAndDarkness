using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class EscMenu : MonoBehaviour
{
    [SerializeField]
    private string _mainMenu;
    private float timeScaleSave;

    [SerializeField] private AudioSource _menuAudio;
    [SerializeField] private AudioClip[] _clickSounds;
    private Random _random = new Random();

    public void Load()
    {
        PlayClickSound();
        Time.timeScale = timeScaleSave;
        var scenePath = SceneManager.GetActiveScene().path;
        LoadSystem.LoadSceneFromSave(scenePath, SaveSystem.LoadGame());
    }

    public void ChangeStatus()
    {
        if (gameObject.activeSelf)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void InMainMenu()
    {
        Time.timeScale = timeScaleSave;
        LoadSystem.LoadScene(_mainMenu);
    }

    private void Open()
    {
        PlayClickSound();
        Cursor.visible = true;
        timeScaleSave = Time.timeScale;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    private void Close()
    {
        PlayClickSound();
        Cursor.visible = false;
        Time.timeScale = timeScaleSave;
        gameObject.SetActive(false);
    }

    private void PlayClickSound()
    {
        _menuAudio.PlayOneShot(_clickSounds[_random.Next(_clickSounds.Length)]);
    }
}
