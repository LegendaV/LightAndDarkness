using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void LoadGame()
    {
        var asyncOp = SceneManager.LoadSceneAsync(_startGameScene.name, LoadSceneMode.Single);
        asyncOp.allowSceneActivation = false;
        while (!asyncOp.isDone)
        {
            if (asyncOp.progress >= 0.9f)
            {
                break;
            }
        }
        asyncOp.allowSceneActivation = true;
        asyncOp.completed += operation =>
        {
            var nextScene = SceneManager.GetSceneByName(_startGameScene.name);
            var all = FindObjectsOfType<EnemySpawner>();
            foreach (var gameObject in all)
            {
                gameObject.SetNotAlive();
            }
        };
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}