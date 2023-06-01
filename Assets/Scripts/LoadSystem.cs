using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSystem : MonoBehaviour
{
    public static void LoadScene(string scene)
    {
        var asyncOp = Load(scene);
        asyncOp.allowSceneActivation = true;
        asyncOp.completed += operation =>
        {
            var nextScene = SceneManager.GetSceneByName(scene);
            var frames = FindObjectsOfType<GameObject>().Where(g => g.CompareTag("Frame")).ToList();
            frames.ForEach(f => f.SetActive(false));
        };
    }

    public static void LoadSceneFromSave(string scene, GameData loadData)
    {
        var asyncOp = Load(scene);
        asyncOp.allowSceneActivation = true;
        asyncOp.completed += operation =>
        {
            var nextScene = SceneManager.GetSceneByName(scene);
            var all = FindObjectsOfType<GameObject>();
            var frames = new List<GameObject>();
            foreach (var gameObject in all)
            {
                if (gameObject.TryGetComponent<DialogueItem>(out var dialog))
                {
                    var pos = gameObject.transform.position;
                    if (dialog.IsForced && !loadData.Dialogs.Contains((pos.x, pos.y, pos.z)))
                    {
                        dialog.IsForced = false;
                    }
                }
                if (gameObject.CompareTag("Spawner"))
                {
                    var pos = gameObject.transform.position;
                    if (!loadData.Environment.Contains((pos.x, pos.y, pos.z)))
                    {
                        var spawner = gameObject.GetComponent<SpawnerScript>();
                        spawner.IsDestroyed = true;
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

    private static AsyncOperation Load(string sceneName)
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
}
