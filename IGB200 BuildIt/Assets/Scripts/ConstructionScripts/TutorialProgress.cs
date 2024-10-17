using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialProgress : MonoBehaviour
{
    public DialogueList dialogue;

    public GameObject[] animations;

    public int progress = 0;
    private int currentTutorialText = 1000;
    public bool slice = false;
    public DetectOverlap blueprint;

    private void Update()
    {
        if (GameManager.instance.tutorialActive)
        {
            switch (progress)
            {
                case 0:
                    StartTutorialText(0);
                    if (Input.GetKeyDown(KeyCode.Mouse0) && TutorialEnqueue.Instance.textFinished)
                        progress = 1;
                    break;
                case 1:
                    StartTutorialText(1);
                    animations[0].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Mouse0) && TutorialEnqueue.Instance.textFinished)
                        progress = 2;
                    break;
                case 2:
                    if (progress != currentTutorialText)
                    {
                        ExitDialogue();
                        currentTutorialText = 2;
                    }
                    if (slice) // change to saw cut detection
                        progress = 3;
                    break;
                case 3:
                    StartTutorialText(3);
                    animations[0].SetActive(false);
                    animations[1].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Mouse1) && TutorialEnqueue.Instance.textFinished)
                        progress = 4;
                    break;
                case 4:
                    if (progress != currentTutorialText)
                    {
                        ExitDialogue();
                        currentTutorialText = 4;
                    }
                    if (blueprint.Overlap().x > 4) // change to blueprint detection  
                        progress = 5;
                    break;
                case 5:
                    StartTutorialText(5);
                    animations[1].SetActive(false);
                    if (Input.GetKeyDown(KeyCode.Mouse0) && TutorialEnqueue.Instance.textFinished)
                        progress = 6;
                    break;
                case 6:
                    if (progress != currentTutorialText)
                    {
                        ExitDialogue();
                        currentTutorialText = 4;
                    }
                    GameManager.instance.tutorialActive = false;
                    GameManager.instance.firstTime = false;
                    break;
                default:
                    animations[0].SetActive(false);
                    animations[1].SetActive(false);
                    ExitDialogue();
                    break;
            }
        }
    }

    public void StartTutorialText(int tutorialNum)
    {
        if (tutorialNum != currentTutorialText)
        {
            DialogueList welcomeDialouge = new DialogueList();
            welcomeDialouge.dialogueLines.Add(dialogue.dialogueLines[tutorialNum]);

            TutorialEnqueue.Instance.StartDialogue(welcomeDialouge);
            currentTutorialText = tutorialNum;
        }
    }

    public void TriggerDialogue()
    {
        TutorialEnqueue.Instance.StartDialogue(dialogue);
    }

    public void ExitDialogue()
    {
        TutorialEnqueue.Instance.EndDialogue();
    }
}
