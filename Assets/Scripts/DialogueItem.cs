using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueItem : MonoBehaviour
{
    [SerializeField] private string[] _dialogueLines;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private bool _isForced = false;

    private bool _triggered;
    private GameObject _button;

    public bool IsForced { get => _isForced; set => _isForced = value; }

    private void Start()
    {
        _button = Instantiate(_buttonPrefab, transform.position + new Vector3(0, 1, 0), transform.rotation);
        _button.transform.SetParent(gameObject.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _triggered = true;
            _button.SetActive(true);            
            var dialogue = collision.gameObject.GetComponent<PlayerDialogue>();
            dialogue.SetDialogueLines(_dialogueLines);
            if (_isForced)
            {
                _isForced = false;
                dialogue.StartDialog = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _triggered = false;
            _button.SetActive(false);
            var dialogue = collision.gameObject.GetComponent<PlayerDialogue>();
            dialogue.ResetDialogueLines();
        }
    }
}
