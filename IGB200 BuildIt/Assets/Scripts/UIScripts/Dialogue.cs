using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    // Inspector Adjustable Variables
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public GameObject dialogueBox;

    // Track Dialogue and NPC's
    private string[] lines;
    
    // Tracks current dialogue tree
    private int index;

    // Tracks which dialogue tree to move to
    private int activeDialogue = 0;
    
    private int previousNPC = 0;
    private bool scriptActive = false;
    private bool shopActive = false;

    // Dialogue Lists per NPC type
    private List<string[]> npc1DialogueList = new List<string[]>() 
    {
        new string[] { "Hi my name is NPC 1, I like to buy products that are mass produced" },

        new string[] { "I always find following the blueprint to give the best results, can't go wrong with the instructions!" }
    };

    private List<string[]> npc2DialogueList = new List<string[]>()
    {
        new string[] { "Hi my name is NPC 2, I like to buy products that are technical" },

        new string[] { "Using complex tools in an effective is the best way to show expertise" }
    };

    private List<string[]> npc3DialogueList = new List<string[]>()
    {
        new string[] { "Hi my name is NPC 3, I like to buy products that are creative" },

        new string[] { "Let your creatviity flow through your projects, nothing like showcasing something unique and different for the client" }
    };

    private List<string[]> defaultShopDialogue = new List<string[]>()
    {
        new string[] { "What would you like to sell?" }
    };

    public void StartDialogue(int activeNPC)
    {
        textComponent.text = string.Empty;
        scriptActive = true;

        // Check if NPC has been spoken to if not reset dialogue tree
        if (activeNPC != previousNPC)
        {
            index = 0;
            shopActive = false;
            previousNPC = activeNPC;
        }

        // Check if NPC shop is active
        if (activeNPC == 4) 
        {
            shopActive = true;
        }

        if (activeDialogue > 1)
        {
            activeDialogue = 0;
        }

        // Load in the correct NPC Dialogue tree
        if (activeNPC == 1)
        {
            lines = npc1DialogueList[activeDialogue];
        }
        if (activeNPC == 2)
        {
            lines = npc2DialogueList[activeDialogue];
        }
        if (activeNPC == 3)
        {
            lines = npc3DialogueList[activeDialogue];
        }
        if (activeNPC == 4)
        {
            lines = defaultShopDialogue[0];
        }

        StartCoroutine(TypeLine());
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptActive)
        {
            if (!shopActive) 
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (textComponent.text == lines[index])
                    {
                        NextLine();
                    }
                    else
                    {
                        StopAllCoroutines();
                        textComponent.text = lines[index];
                    }
                }
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
            scriptActive = false;
            activeDialogue += 1;
        }
    }
}
