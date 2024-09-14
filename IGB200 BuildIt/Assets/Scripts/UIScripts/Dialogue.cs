using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    // Stores a list of dialogue strings that can be used
    // going to try implement an inspector version of this to keep it easy... - Evan
    public List<string[]> dialogueList = new List<string[]>() 
    {
        new string[] { "Hi this is dialogue 1 speaking here", 
            "yup just confirming I am dialogue 1 here lol"},

        new string[] {"This is dialogue 2 I am hoping it will just loop around to this yuuupp"}
    };

    private int ActiveDialogue = 0;
    
    private string[] lines;
    public float textSpeed;

    private int index;

    void OnEnable()
    {
        // Ideally this random range loops through the list, but if the object is inactive this won't work, need to figure out a solution to this - Evan
        lines = dialogueList[Random.Range(0,2)];
            
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
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

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
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
            gameObject.SetActive(false);
        }
    }
}
