using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEdit : MonoBehaviour
{
    public string ButtonName;

    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Button _button;

    private bool isChanging = false;

    void Start()
    {
        var key = KeyLayout.GetKey(ButtonName);
        _text.text = $"{ButtonName} : {key}";
    }

    void Update()
    {
        if (isChanging && Input.anyKeyDown)
        {
            var newKey = KeyCode.None;
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(key))
                {
                    newKey = key;
                    break;
                }
            }
            KeyLayout.SetKey(ButtonName, newKey);
            _text.text = $"{ButtonName} : {newKey}";
            _button.interactable = true;
            isChanging = false;
        }
    }

    public void ChangeButton()
    {
        isChanging = true;
        _button.interactable = false;
    }
}
