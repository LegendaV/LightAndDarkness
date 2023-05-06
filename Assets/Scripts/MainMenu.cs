using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneAsset _startGameScene;

    public void StartGame()
    {
        LoadSystem.LoadScene(_startGameScene);
    }
    
    public void LoadGame()
    {
        LoadSystem.LoadSceneFromSave(_startGameScene, SaveSystem.LoadGame());
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}