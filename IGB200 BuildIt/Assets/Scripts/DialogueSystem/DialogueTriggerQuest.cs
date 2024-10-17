using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerQuest : MonoBehaviour
{
    public DialogueList pending_Quest;
    public DialogueList quest_Dialogue;
    public DialogueList completed_Dialogue;
    public DialogueList finished_Dialogue;


    public DialogueManager dialogueManagerScript;

    // Set the size of the dialogue box
    public float dialogueBoxWidth;
    public float dialogueBoxHeight;

    public void TriggerDialogue()
    {
        // Check based on the following order
            // 1. Check if the quest is now completed.
            // 2. Check if the quest has been completed
            // 3. Check if the quest is still pending. // Not needed for quest 1
            // 4. check if the quest is active.
        if (GameManager.instance.activeShop == 1)
        {
            if (GameManager.instance.questactive == 1 && GameManager.instance.fiveStarPlanksCount >= 3)
            {
                GameManager.instance.quest1complete = true;
                GameManager.instance.questactive += 1;
                DialogueManager.Instance.StartDialogue(completed_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }
            else if (GameManager.instance.quest1complete && GameManager.instance.questactive != 1)
            {
                DialogueManager.Instance.StartDialogue(finished_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }
            else if (GameManager.instance.questactive == 1 && !GameManager.instance.quest1complete)
            {
                quest_Dialogue.dialogueLines[2].line = "Current Progress: " + GameManager.instance.fiveStarPlanksCount.ToString() + "/3";
                DialogueManager.Instance.StartDialogue(quest_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }
        }

        if (GameManager.instance.activeShop == 2)
        {
            if (GameManager.instance.questactive == 2 && GameManager.instance.threeStarSignCount >= 3)
            {
                GameManager.instance.quest2complete = true;
                GameManager.instance.questactive += 1;
                DialogueManager.Instance.StartDialogue(completed_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }
            else if (GameManager.instance.quest2complete && GameManager.instance.questactive != 2)
            {
                DialogueManager.Instance.StartDialogue(finished_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }
            else if (GameManager.instance.questactive != 2 && !GameManager.instance.quest2complete)
            {
                DialogueManager.Instance.StartDialogue(pending_Quest, dialogueBoxWidth, dialogueBoxHeight);
            }
            else if (GameManager.instance.questactive == 2 && !GameManager.instance.quest2complete)
            {
                quest_Dialogue.dialogueLines[1].line = "Current Progress: " + GameManager.instance.threeStarSignCount.ToString() + "/3";
                DialogueManager.Instance.StartDialogue(quest_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }
        }

        if (GameManager.instance.activeShop == 3)
        {
            if (GameManager.instance.questactive == 3 && GameManager.instance.money >= 500)
            {
                GameManager.instance.quest3complete = true;
                GameManager.instance.questactive += 1;
                DialogueManager.Instance.StartDialogue(completed_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }
            else if (GameManager.instance.quest3complete && GameManager.instance.questactive != 3)
            {
                DialogueManager.Instance.StartDialogue(finished_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }
            else if (GameManager.instance.questactive != 3 && !GameManager.instance.quest3complete)
            {
                DialogueManager.Instance.StartDialogue(pending_Quest, dialogueBoxWidth, dialogueBoxHeight);
            }
            else if (GameManager.instance.questactive == 3 && !GameManager.instance.quest3complete)
            {
                quest_Dialogue.dialogueLines[1].line = "Current Progress: $" + GameManager.instance.money.ToString() + "/$500";
                DialogueManager.Instance.StartDialogue(quest_Dialogue, dialogueBoxWidth, dialogueBoxHeight);
            }   
        }
    }

    public void ExitDialogue()
    {
        DialogueManager.Instance.EndDialogue();
    }
}
