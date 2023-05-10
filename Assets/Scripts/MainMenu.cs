using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneAsset _startGameScene;
    [SerializeField]
    private GameObject _setMenu;

    public void StartGame()
    {
        LoadSystem.LoadScene(_startGameScene);
    }
    
    public void LoadGame()
    {
        LoadSystem.LoadSceneFromSave(_startGameScene, SaveSystem.LoadGame());
    }

    public void OpenSetMenu()
    {
        gameObject.SetActive(false);
        _setMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}