using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Info_UI : MonoBehaviour
{
    public GameObject[] CanvasList;
    public TextMeshProUGUI[] ObjectList;

    // Reference to the tutorial class
    public Tutorial tutorial;

    private void Start()
    {
        // Set the player name upon scene being started up
        CanvasList[3].GetComponent<TextMeshProUGUI>().text = "Name: " + GameManager.instance.playerName;
    }

    public void ToDoList()
    {
        // Adjust variables based on completness
        if (GameManager.instance.quest1complete)
        {
            ObjectList[0].fontStyle = FontStyles.Strikethrough;
        }
        if (GameManager.instance.quest2complete)
        {
            ObjectList[1].fontStyle = FontStyles.Strikethrough;
        }
        if (GameManager.instance.quest3complete)
        {
            ObjectList[2].fontStyle = FontStyles.Strikethrough;
        }

        CanvasList[1].SetActive(true);
        CanvasList[0].SetActive(false);

        // Resets To Do List to top of list
        CanvasList[2].GetComponent<ScrollRect>().verticalNormalizedPosition = 1;

        // When the player selects the to do list in tutorial advance it and allow click
        if (GameManager.instance.tutorialActive && tutorial.DialogueIndex == 1)
        {
            tutorial.IndexClick();
            tutorial.canClick = true;
        }
    }   

    public void PlayerInfo()
    {
        CanvasList[0].SetActive(true);
        CanvasList[1].SetActive(false);
    }
}
