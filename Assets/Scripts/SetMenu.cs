using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenu;
    [SerializeField]
    private GameObject _buttonEdit;

    private Vector2 currentButtonEditPos = new Vector2(-420, 420);

    void Start()
    {
        foreach (var element in KeyLayout.GetAllKey())
        {
            var buttonEdit = Instantiate(_buttonEdit);
            var script = buttonEdit.GetComponent<ButtonEdit>();
            script.ButtonName = element.Key;
            buttonEdit.transform.SetParent(transform, false);
            var pos = buttonEdit.GetComponent<RectTransform>();
            pos.anchoredPosition = currentButtonEditPos;
            currentButtonEditPos.y -= 100;
            if (currentButtonEditPos.y < -180)
            {
                currentButtonEditPos = new Vector2(420, 420);
            }
        }
    }

    public void Exit()
    {
        gameObject.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
