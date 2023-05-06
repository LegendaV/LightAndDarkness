using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardController : MonoBehaviour
{
    [SerializeField]
    private EscMenu _escMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log("SAVE, please will be correct");
            SaveSystem.SaveGame(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            _escMenu.ChangeStatus();
        }
    }
}
