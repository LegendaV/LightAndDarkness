using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    //PlayerData
    public float[] PlayerPosition;
    public int Energy;
    public float JumpForce;
    public float Speed;
    public float DashForce;
    public float[] Checkpoint;
    public float LightPower;

    //Enemyes Data
    public HashSet<(float, float, float)> aliveEnemyes;

    public GameData(string sceneName)
    {
        var allObjects = GetAllObjects(sceneName);
        aliveEnemyes = new HashSet<(float, float, float)>();

        foreach (var gameObject in allObjects)
        {
            if (gameObject.CompareTag("EnemySpawner"))
            {
                if (gameObject.GetComponent<EnemySpawner>().IsAlive)
                {
                    var pos = gameObject.transform.position;
                    aliveEnemyes.Add((pos.x, pos.y, pos.z));
                }
            }
            else if (gameObject.CompareTag("Player"))
            {
                SavePlayer(gameObject);
            }
        }
    }

    private void SavePlayer(GameObject player)
    {
        if (player.CompareTag("Player"))
        {
            var positionVector = player.transform.position;
            PlayerPosition = new[] { positionVector.x, positionVector.y, positionVector.z };
            var playerStats = player.GetComponent<PlayerStats>();
            Energy = playerStats.Energy;
            JumpForce = playerStats.JumpForce;
            Speed = playerStats.Speed;
            DashForce = playerStats.DashForce;
            var checkpointVector = playerStats.Checkpoint;
            Checkpoint = new[] { checkpointVector.x, checkpointVector.y };
            LightPower = playerStats.LightPower;
        }
    }

    private List<GameObject> GetAllObjects(string sceneName)
    {
        var scene = SceneManager.GetSceneByName(sceneName);
        var rootObjects = scene.GetRootGameObjects().ToList();
        var allObjects = new List<GameObject>();
        foreach (GameObject rootObject in rootObjects)
        {
            allObjects.AddRange(rootObject.GetComponentsInChildren<Transform>(true).Select(t => t.gameObject));
        }
        return allObjects;
    }
}