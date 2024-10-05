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

                if (CanvasDialogue[3].activeSelf == false)
                {
                    CanvasDialogue[1].SetActive(true);
                }
            }
        }
    }

    public void StartDialogue(DialogueList dialogue)
    {
        isDialogueActive = true;
        CanvasDialogue[0].SetActive(true);
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
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (CanvasDialogue[3].activeSelf == false) 
        {
            CanvasDialogue[1].SetActive(true);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        CanvasDialogue[0].SetActive(false);
        CanvasDialogue[1].SetActive(false);
        CanvasDialogue[2].SetActive(true);
    }
}
