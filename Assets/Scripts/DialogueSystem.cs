using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Random = System.Random;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _typingAudio;
    [SerializeField] private AudioClip[] _typingSounds;
    private Random _random = new Random();
    
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _textSpeed;
    [SerializeField] private string[] _dialogueLines;

    [SerializeField] private PlayerStats _playerStats;
    
    private int _currentLineIndex;

    private void Update()
    {
        if (_dialogueLines != null)
        {
            if (Input.GetKeyDown(KeyLayout.Dialog))
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
        _playerStats.InDialogue = true;
        StartDialogue();
    }

    private void ResetDialogueLines()
    {
        _dialogueLines = null;
        _playerStats.InDialogue = false;
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
            _typingAudio.PlayOneShot(_typingSounds[_random.Next(_typingSounds.Length)]);
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
            ResetDialogueLines();
        }
    }
}
