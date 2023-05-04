using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _textSpeed;
    [SerializeField] private string[] _dialogueLines;

    private int _currentLineIndex;

    private void Update()
    {
        if (_dialogueLines != null)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (_text.text == _dialogueLines[_currentLineIndex])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    _text.text = _dialogueLines[_currentLineIndex];
                }
            }
        }        
    }

    public void SetDialogueLines(string[] lines)
    {
        if (gameObject.activeSelf)
            return;

        _dialogueLines = lines.ToArray();
        gameObject.SetActive(true);
        StartDialogue();
    }

    private void ResetDialogueLines()
    {
        _dialogueLines = null;
        gameObject.SetActive(false);
    }

    private void StartDialogue()
    {
        _text.text = string.Empty;
        _currentLineIndex = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (var ch in _dialogueLines[_currentLineIndex].ToCharArray())
        {
            _text.text += ch;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private void NextLine()
    {
        if (_currentLineIndex < _dialogueLines.Length - 1)
        {
            _currentLineIndex++;
            _text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
