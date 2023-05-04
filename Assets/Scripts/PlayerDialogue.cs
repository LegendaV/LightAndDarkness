using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    [SerializeField] private DialogueSystem _dialogueSystem;

    private string[] _dialogueLines;

    public void SetDialogueLines(string[] lines)
    {
        _dialogueLines = lines.ToArray();
    }

    public void ResetDialogueLines()
    {
        _dialogueLines = null;
    }

    private void Update()
    {
        if (_dialogueLines is not null)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                _dialogueSystem.SetDialogueLines(_dialogueLines);
            }
        }
    }
}
