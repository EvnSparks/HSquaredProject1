using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TextMeshProUGUI dialogueArea;

    public GameObject[] CanvasDialogue;
    private Queue<DialogueLine> lines;
    DialogueLine currentLine;

    public bool isDialogueActive = false;
    public float typingSpeed = 0.05f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopAllCoroutines();
                dialogueArea.text = currentLine.line;

                // Only shows the continue/ exit buttons if all inventories and exit workshop button is off
                // The following is very inelegant but idk how else to fix this... - Evan

                if (GameManager.instance.activeShop == 3)
                {
                    if (CanvasDialogue[2].activeSelf == false && CanvasDialogue[5].activeSelf == false)
                    {
                        CanvasDialogue[1].SetActive(true);
                        CanvasDialogue[4].SetActive(true);
                    }
                }
                if (GameManager.instance.activeShop == 1 || GameManager.instance.activeShop == 2)
                {
                    if (CanvasDialogue[2].activeSelf == false && CanvasDialogue[3].activeSelf == false)
                    {
                        CanvasDialogue[1].SetActive(true);
                        CanvasDialogue[4].SetActive(true);
                    }
                }
            }
        }

        // Check GameManager for First Time Check, if true then do the following
        if(GameManager.instance.firstTime)
        {
            typingSpeed = 0;
        }
        else
        {
            typingSpeed = 0.05f;
        }
    }

    public void StartDialogue(DialogueList dialogue, float dialogueBoxWidth, float dialogueBoxHeight)
    {
        isDialogueActive = true;
        
        // Dialogue Box is set to active
        CanvasDialogue[0].SetActive(true);

        // Set the size of the dialogue box
        RectTransform box = CanvasDialogue[0].GetComponent<RectTransform>();
        box.sizeDelta = new Vector2(dialogueBoxWidth, dialogueBoxHeight);
        
        CanvasDialogue[2].SetActive(false);

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        currentLine = lines.Dequeue();

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));

        CanvasDialogue[1].SetActive(false);
        CanvasDialogue[4].SetActive(false);
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // If the shop exit is off and the text has finished being typed turn on the continue and exit conversation buttons.
        if (CanvasDialogue[3].activeSelf == false) 
        {
            CanvasDialogue[1].SetActive(true);
            CanvasDialogue[4].SetActive(true);
        }
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        CanvasDialogue[0].SetActive(false);
        CanvasDialogue[1].SetActive(false);
        CanvasDialogue[2].SetActive(true);
        CanvasDialogue[4].SetActive(false);
    }
}
