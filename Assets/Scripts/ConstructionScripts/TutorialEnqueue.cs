using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// stripped down version of NPC dialogue
public class TutorialEnqueue : MonoBehaviour
{
    public static TutorialEnqueue Instance;

    public TextMeshProUGUI dialogueArea;

    public GameObject[] CanvasDialogue;

    private Queue<DialogueLine> lines;

    DialogueLine currentLine;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.05f;

    public bool textFinished = false;

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
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            {
                typingSpeed = 0.005f;
                // This is the potential fault/ bug issue here.
                //DisplayNextDialogueLine();
            }
            else typingSpeed = 0.05f;
        }
    }

    public void StartDialogue(DialogueList dialogue)
    {
        textFinished = false;
        isDialogueActive = true;
        CanvasDialogue[0].SetActive(true);

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
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        textFinished = true;
    }
    public void EndDialogue()
    {
        isDialogueActive = false;
        CanvasDialogue[0].SetActive(false);
        dialogueArea.text = "";
    }
}
