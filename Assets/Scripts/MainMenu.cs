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
        var asyncOp = LoadScene(_startGameScene.name);
        asyncOp.allowSceneActivation = true;
        asyncOp.completed += operation =>
        {
            var nextScene = SceneManager.GetSceneByName(_startGameScene.name);
            var frames = FindObjectsOfType<GameObject>().Where(g => g.CompareTag("Frame")).ToList();
            frames.ForEach(f => f.SetActive(false));
        };
    }

    public void LoadGame()
    {
        var loadData = SaveSystem.LoadGame();
        var asyncOp = LoadScene(_startGameScene.name);
        asyncOp.allowSceneActivation = true;
        asyncOp.completed += operation =>
        {
            var nextScene = SceneManager.GetSceneByName(_startGameScene.name);
            var all = FindObjectsOfType<GameObject>();
            var frames = new List<GameObject>();
            foreach (var gameObject in all)
            {
                if (gameObject.CompareTag("EnemySpawner"))
                {
                    var pos = gameObject.transform.position;
                    if (!loadData.aliveEnemyes.Contains(( pos.x, pos.y, pos.z )))
                    {
                        var spawner = gameObject.GetComponent<EnemySpawner>();
                        spawner.IsAlive = false;
                    }
                }
                else if (gameObject.CompareTag("Frame"))
                {
                    frames.Add(gameObject);
                }
                else if (gameObject.CompareTag("Player"))
                {
                    gameObject.GetComponent<PlayerStats>().LoadPlayer(loadData);
                }
            }
            frames.ForEach(g => g.SetActive(false));
        };
    }

    private AsyncOperation LoadScene(string sceneName)
    {
        var asyncOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncOp.allowSceneActivation = false;
        while (!asyncOp.isDone)
        {
            if (asyncOp.progress >= 0.9f)
            {
                break;
            }
        }
        return asyncOp;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}