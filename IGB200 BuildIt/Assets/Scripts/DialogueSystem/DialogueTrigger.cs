using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inspector Variable to adjust Text
[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string line;
}
[System.Serializable]
public class DialogueList
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public DialogueList dialogue;

    public DialogueManager dialogueManagerScript;

    // Set the size of the dialogue box
    public float dialogueBoxWidth;
    public float dialogueBoxHeight;

    public void ShopWelcome(int activeShop)
    {
        DialogueList welcomeDialouge = new DialogueList();
        welcomeDialouge.dialogueLines.Add(dialogue.dialogueLines[activeShop - 1]);

        DialogueManager.Instance.StartDialogue(welcomeDialouge, dialogueBoxWidth, dialogueBoxHeight);
    }

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue, dialogueBoxWidth, dialogueBoxHeight);
    }

    public void ExitDialogue()
    {
        DialogueManager.Instance.EndDialogue();
    }
}
