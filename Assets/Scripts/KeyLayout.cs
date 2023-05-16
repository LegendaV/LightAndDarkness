using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyLayout
{
    private static readonly Dictionary<string, KeyCode> keysLayout = new Dictionary<string, KeyCode>
    {
        { "������", KeyCode.C },
        { "�����", KeyCode.X },
        { "��������", KeyCode.Z },
        { "�����", KeyCode.Escape },
        { "�����������������", KeyCode.V }
    };

    public static KeyCode Jump { get => keysLayout["������"]; set => keysLayout["������"] = value; }
    public static KeyCode Dash { get => keysLayout["�����"]; set => keysLayout["�����"] = value; }
    public static KeyCode Shoot { get => keysLayout["��������"]; set => keysLayout["��������"] = value; }
    public static KeyCode PauseMenu { get => keysLayout["�����"]; set => keysLayout["�����"] = value; }
    public static KeyCode Dialog { get => keysLayout["�����������������"]; set => keysLayout["�����������������"] = value; }

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
