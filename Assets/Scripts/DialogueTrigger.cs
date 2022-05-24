using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Field for targeting the dialogue that is affected by this trigger.
    public Dialogue Dialogue;

    // Bool field to allow the player to clear the dialogue when pressing the interact button
    private bool _isStall = false;

    private DialogueManager _dialogueManager;

    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Loads and runs the dialogue given by the dialogue variable.
    public void TriggerDialogue()
    {
        _dialogueManager.StartDialogue(Dialogue);
    }
    
    // Runs the dialogue given by the dialogue variable if it has been loaded.
    public void ContinueDialogue()
    {
        _dialogueManager.DisplayNextSentence();
    }
}
