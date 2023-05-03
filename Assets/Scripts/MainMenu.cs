using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneAsset _startGameScene;

    public void StartGame()
    {
        SceneManager.LoadScene(_startGameScene.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}