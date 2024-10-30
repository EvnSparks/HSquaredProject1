using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialProgress : MonoBehaviour
{
    public DialogueList dialogue;

    public GameObject[] animations;

    public CameraMovement camera;

    public int progress = 0;
    private int currentTutorialText = 1000;
    public bool slice = false;
    public DetectOverlap blueprint;
    public Animator animator;
    public bool create = false;

    private void Start()
    {
        if (GameManager.instance.projectType == InventoryItem.ProjectType.Sign)
        {
            progress = 7;
        }
        else if (GameManager.instance.projectType == InventoryItem.ProjectType.Table || (GameManager.instance.projectType == InventoryItem.ProjectType.Plank && GameManager.instance.secondTutorialStage))
        {
            progress = 12;
        }
    }

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
                    if (slice)
                    {
                        progress = 3;
                        slice = false;
                    }  
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
                        currentTutorialText = 6;
                    }
                    GameManager.instance.secondTutorialStage = true;
                    GameManager.instance.firstTime = false;
                    break;
                case 7:
                    StartTutorialText(7);
                    if ((camera.angley > 80 && camera.angley < 280) && TutorialEnqueue.Instance.textFinished)
                        progress = 8;
                    break;
                case 8:
                    StartTutorialText(8);
                    if (slice && TutorialEnqueue.Instance.textFinished)
                    {
                        progress = 9;
                        slice = false;
                    }
                        
                    break;
                case 9:
                    StartTutorialText(9);
                    animator.SetTrigger("MoveTutorial");
                    if (Input.GetKeyDown(KeyCode.Mouse0) && TutorialEnqueue.Instance.textFinished)
                    {
                        progress = 10;
                        create = false;
                    }
                    break;
                case 10:
                    if (progress != currentTutorialText)
                    {
                        ExitDialogue();
                        currentTutorialText = 10;
                    }
                    if (create)
                    {
                        progress = 11;
                        create = false;
                    }
                    break;
                case 11:
                    StartTutorialText(11);

                    if (Input.GetKeyDown(KeyCode.Mouse0) && TutorialEnqueue.Instance.textFinished)
                    {
                        progress = 12;
                        animations[0].SetActive(false);
                        animations[1].SetActive(false);
                        ExitDialogue();
                        GameManager.instance.tutorialActive = false;
                    }
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
