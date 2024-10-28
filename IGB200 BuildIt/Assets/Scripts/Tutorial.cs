using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Track Dialogue States
    public bool canClick = true;

    public bool isTutorialCompleted;
    
    //toggle visible
    private GameObject TutorialPanel, StartButtons, prompt;

    //toggle buttons
    private GameObject GameStartB,ShopB;
    
    
    /// <summary>
    ///  In this Order ShopHome1,ShopB1,ShopB2,ShopB3;
    /// </summary>
    public GameObject[] ActiveButtons;

    //panel transform locations
    private GameObject location1,location2,location3;
    private TMP_Text TutText;

    //Bring the player through step by step
    public string[] TutDialogue;
    //Arrows should correspond to the index of TutDialogue
    public GameObject[] TutArrows;

    //I guess we have to make this public now to make this accessible cuz debugging is hard.
    public int DialogueIndex = 0;
    public int ArrowIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        TutorialPanel = GameObject.Find("TutorialPanel");
        StartButtons = GameObject.Find("StartButtons");
        prompt = GameObject.Find("PromptTut1");
        GameObject TutTextObj = GameObject.Find("TutText");
        TutText = TutTextObj.GetComponent<TMP_Text>();

        GameStartB = GameObject.Find("CraftButton");
        ShopB = GameObject.Find("Shop");

        location1 = GameObject.Find("Location1");
        location2 = GameObject.Find("Location2");
        location3 = GameObject.Find("Location3");

        prompt.SetActive(false);

        //if incomplete ask player if they want to do tutorial
        if(isTutorialCompleted)
        {
            TutorialPanel.SetActive(false);

        }
    }

    
    void Update()
    {
        if(GameManager.instance.tutorialActive)
        {
            Debug.Log(DialogueIndex);
            prompt.SetActive(true);

            IndexLogic();
            
            if(Input.GetMouseButtonDown(0))
            {
                if(canClick)
                {
                    IndexClick();
                }
            }
        }
    }

    public void EnableTutorial()
    {
        GameManager.instance.tutorialActive = true;

        TutText.text = TutDialogue[0];
        StartButtons.SetActive(false);

    }

    public void FinishTutorial()
    {
        TutorialPanel.SetActive(false);
        GameManager.instance.tutorialActive = false;
        SceneManager.LoadScene("WorkShop");
    }

    //When Click increase the index and cycle through the tutorial
    public void IndexClick()
    {
        if(DialogueIndex < TutDialogue.Length -1)
        {
            DialogueIndex++;
            ArrowIndex++;
            if(DialogueIndex < TutDialogue.Length && ArrowIndex < TutArrows.Length)
            {
                //display corresponding tutorial text
                TutText.text = TutDialogue[DialogueIndex];
                //Delete the previous arrow and show the next one
                //tired so lets not put an arrow image at index 0 cuz I think it won't show
                if(TutArrows[ArrowIndex] != null && ArrowIndex > 0)
                {
                    TutArrows[ArrowIndex -1].SetActive(false);
                    TutArrows[ArrowIndex].SetActive(true);
                }
            }
        }
    }

    //Enabling and disabling buttons, moving panel around etc...
    public void IndexLogic()
    {
        if(DialogueIndex ==0)
        {
            GameStartB.GetComponent<Button>().interactable = false;
            ShopB.GetComponent<Button>().interactable = false;
        }

        if (DialogueIndex == 1)
        {
            canClick = false;
            prompt.SetActive(false);
        }

        if(DialogueIndex ==3)
        {
            canClick = false;
            prompt.SetActive(false);
            ShopB.GetComponent<Button>().interactable = true;
            TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location1.transform.position,10f);
        }
        if(DialogueIndex ==5)
        {
            ActiveButtons[0].GetComponent<Button>().interactable = false;
            ActiveButtons[1].GetComponent<Button>().interactable = false;
            ActiveButtons[2].GetComponent<Button>().interactable = false;
            ActiveButtons[3].GetComponent<Button>().interactable = false;
            TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location2.transform.position,10f);
        }
        if(DialogueIndex == 8)
        {
            canClick = false;
            prompt.SetActive(false);
            ActiveButtons[1].GetComponent<Button>().interactable = true;
        }

        if(DialogueIndex == 9)
        {
            TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location1.transform.position,10f);
        }

        if(DialogueIndex ==10)
        {
            TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position, location1.transform.position, 10f);
            canClick = false;
            prompt.SetActive(false);
            ActiveButtons[11].SetActive(true);
            ActiveButtons[0].GetComponent<Button>().interactable = true;
            ActiveButtons[1].GetComponent<Button>().interactable = false;
            ActiveButtons[2].GetComponent<Button>().interactable = false;
            ActiveButtons[3].GetComponent<Button>().interactable = false;
        }

        if (DialogueIndex == 11)
        {
            prompt.SetActive(false);
        }

        if(DialogueIndex ==12)
        {
            canClick = false;
            prompt.SetActive(false);
            ShopB.GetComponent<Button>().interactable = false;
            GameStartB.GetComponent<Button>().interactable = true;
            TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location3.transform.position,10f);
            ActiveButtons[4].GetComponent<Button>().interactable = false;
            ActiveButtons[12].GetComponent<Button>().interactable = false;
            ActiveButtons[5].GetComponent<Button>().interactable = false;
            ActiveButtons[6].GetComponent<Button>().interactable = false;
            ActiveButtons[7].GetComponent<Button>().interactable = false;
            ActiveButtons[8].GetComponent<Button>().interactable = false;
            ActiveButtons[9].GetComponent<Button>().interactable = false;
            ActiveButtons[10].GetComponent<Button>().interactable = false;
        }

        if (DialogueIndex == 13)
        {
            prompt.SetActive(false);
        }

        if (DialogueIndex == 14)
        {
            prompt.SetActive(false);
        }

        if (DialogueIndex == 15)
        {
            canClick = true;
            TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location2.transform.position,10f);
        }
        if(DialogueIndex == 16)
        {
            prompt.SetActive(false);
            TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location3.transform.position,10f);
        }
    } 
}
