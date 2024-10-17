using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public bool isTutorialActive, isTutorialCompleted;
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
        Debug.Log(DialogueIndex);
        if(isTutorialActive)
        {
            prompt.SetActive(true);

            IndexLogic();
            
            if(Input.GetMouseButtonDown(0))
            {
                if(DialogueIndex !=3 && DialogueIndex !=8 && DialogueIndex != 10 && DialogueIndex !=11
                && DialogueIndex !=12 && DialogueIndex !=13 && DialogueIndex != 14)
                {
                    IndexClick();
                }
            }
        }
        else
        {
            
            isTutorialCompleted = true;
            //enable these buttons
            GameStartB.GetComponent<Button>().interactable = true;
            ShopB.GetComponent<Button>().interactable = true;

            //Re-enable all buttons
            for(int i=0; i< ActiveButtons.Length ;i++)
            {
                ActiveButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void EnableTutorial()
    {
        isTutorialActive = true;
        TutText.text = TutDialogue[0];
        GameManager.instance.tutorialActive = true;
        StartButtons.SetActive(false);

    }

    public void DisableTutorial()
    {
        isTutorialActive = false;
        TutorialPanel.SetActive(false);
        GameManager.instance.tutorialActive = false;
        GameManager.instance.firstTime = false;
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

            if(DialogueIndex ==3)
            {
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
                ActiveButtons[1].GetComponent<Button>().interactable = true;
            }

            if(DialogueIndex == 9)
            {
                TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location1.transform.position,10f);
            }

            if(DialogueIndex ==10)
            {
                ActiveButtons[0].GetComponent<Button>().interactable = true;
                ActiveButtons[1].GetComponent<Button>().interactable = false;
                ActiveButtons[2].GetComponent<Button>().interactable = false;
                ActiveButtons[3].GetComponent<Button>().interactable = false;
            }
            if(DialogueIndex ==12)
            {
                GameStartB.GetComponent<Button>().interactable = true;
                TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location3.transform.position,10f);
                ActiveButtons[4].GetComponent<Button>().interactable = false;
                ActiveButtons[5].GetComponent<Button>().interactable = false;
                ActiveButtons[6].GetComponent<Button>().interactable = false;
                ActiveButtons[7].GetComponent<Button>().interactable = false;
                ActiveButtons[8].GetComponent<Button>().interactable = false;
                ActiveButtons[9].GetComponent<Button>().interactable = false;
                ActiveButtons[10].GetComponent<Button>().interactable = false;
            }

            if(DialogueIndex == 15)
            {
                TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location2.transform.position,10f);
            }
            if(DialogueIndex == 16)
            {
                TutorialPanel.transform.position = Vector3.MoveTowards(TutorialPanel.transform.position,location3.transform.position,10f);
            }
    } 
}
