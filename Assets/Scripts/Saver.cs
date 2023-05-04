using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log("SAVE, please will be correct");
            SaveSystem.SaveGame(gameObject);
        }
    }
}
