using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    [SerializeField]
    private SceneAsset _mainMenu;
    private float timeScaleSave;

    public void Load()
    {
        Time.timeScale = timeScaleSave;
        var scenePath = EditorSceneManager.GetActiveScene().path;
        var currentScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        LoadSystem.LoadSceneFromSave(currentScene, SaveSystem.LoadGame());
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
        timeScaleSave = Time.timeScale;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    private void Close()
    {
        Time.timeScale = timeScaleSave;
        gameObject.SetActive(false);
    }
}
