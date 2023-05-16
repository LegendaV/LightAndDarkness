using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyLayout
{
    private static readonly Dictionary<string, KeyCode> keysLayout = new Dictionary<string, KeyCode>
    {
        { "Прыжок", KeyCode.C },
        { "Рывок", KeyCode.X },
        { "Стрельба", KeyCode.Z },
        { "Пауза", KeyCode.Escape },
        { "Взаимодействовать", KeyCode.V }
    };

    public static KeyCode Jump { get => keysLayout["Прыжок"]; set => keysLayout["Прыжок"] = value; }
    public static KeyCode Dash { get => keysLayout["Рывок"]; set => keysLayout["Рывок"] = value; }
    public static KeyCode Shoot { get => keysLayout["Стрельба"]; set => keysLayout["Стрельба"] = value; }
    public static KeyCode PauseMenu { get => keysLayout["Пауза"]; set => keysLayout["Пауза"] = value; }
    public static KeyCode Dialog { get => keysLayout["Взаимодействовать"]; set => keysLayout["Взаимодействовать"] = value; }

    public static KeyCode GetKey(string name)
    {
        if (keysLayout.ContainsKey(name))
        {
            return keysLayout[name];
        }
        return KeyCode.None;
    }

    public static void SetKey(string name, KeyCode key)
    {
        keysLayout[name] = key;
    }

    public static IEnumerable<KeyValuePair<string, KeyCode>> GetAllKey()
    {
        foreach (var element in keysLayout)
        {
            yield return element;
        }
    }
}
