using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class CharacterH2 : InterActiveBase
{
    private DialogueController dialogueController;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    protected override void EmptyClicked()
    {
        if(!isDone)
            dialogueController.ShowDialogueEmpty();
        else
            dialogueController.ShowDialogueFinish();
    }

    protected override void OnClickedAction()
    {
        dialogueController.ShowDialogueFinish();
    }
}
