using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyLayout
{
    private static readonly Dictionary<string, KeyCode> keysLayout = new Dictionary<string, KeyCode>
    {
        { "Jump", KeyCode.C },
        { "Dash", KeyCode.X },
        { "Shoot", KeyCode.Z },
        { "PauseMenu", KeyCode.Escape }
    };

    public static KeyCode Jump { get => keysLayout["Jump"]; set => keysLayout["Jump"] = value; }
    public static KeyCode Dash { get => keysLayout["Dash"]; set => keysLayout["Dash"] = value; }
    public static KeyCode Shoot { get => keysLayout["Shoot"]; set => keysLayout["Shoot"] = value; }
    public static KeyCode PauseMenu { get => keysLayout["PauseMenu"]; set => keysLayout["PauseMenu"] = value; }

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
