using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string DirectoryPath { get; }

    public static void SaveGame(GameObject scene)
    {
        var formatter = new BinaryFormatter();
        if (!Directory.Exists(DirectoryPath))
        {
            Directory.CreateDirectory(DirectoryPath);
        }
        var stream = new FileStream(DirectoryPath + "/Save.lad", FileMode.Create);
        var data = new GameData(scene);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        if (File.Exists(DirectoryPath + "/Save.lad"))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(DirectoryPath + "/Save.lad", FileMode.Open);
            var data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        Debug.LogError($"Save file not found in {DirectoryPath}");
        return null;
    }

    static SaveSystem()
    {
        DirectoryPath = Application.persistentDataPath + "/Saves";
    }
}
