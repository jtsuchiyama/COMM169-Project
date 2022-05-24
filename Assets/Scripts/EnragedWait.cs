using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedWait : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<DialogueBoxManager>().SetVisibility(true);
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.DisplayNextSentence();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<DialogueBoxManager>().SetVisibility(false);
    }
}
