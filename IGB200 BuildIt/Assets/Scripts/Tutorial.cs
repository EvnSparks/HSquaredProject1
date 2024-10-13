using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private bool isTutorialActive;
    private GameObject TutorialPanel, StartButtons, prompt;
    private TMP_Text TutText;

    //Bring the player through step by step
    public string[] TutDialogue;
    //Arrows should correspond to the index of TutDialogue
    public GameObject[] TutArrows;

    private int DialogueIndex = 0;
    private int ArrowIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        TutorialPanel = GameObject.Find("TutorialPanel");
        StartButtons = GameObject.Find("StartButtons");
        prompt = GameObject.Find("PromptTut1");
        GameObject TutTextObj = GameObject.Find("TutText");
        TutText = TutTextObj.GetComponent<TMP_Text>();

        prompt.SetActive(false);
    }

    
    void Update()
    {
        if(isTutorialActive)
        {
            prompt.SetActive(true);
            
            if(Input.GetMouseButton(0))
            {
                DialogueIndex++;
                ArrowIndex++;
                if(DialogueIndex < TutDialogue.Length && ArrowIndex < TutArrows.Length)
                {
                    //display corresponding tutorial text
                    TutText.text = TutDialogue[DialogueIndex];
                    //Delete the previous arrow and show the next one
                    //tired so lets not put an arrow image at index 0 cuz I think it won't show
                    if(TutArrows[ArrowIndex] != null && ArrowIndex <0)
                    {
                        TutArrows[ArrowIndex -1].SetActive(false);
                        TutArrows[ArrowIndex].SetActive(true);
                    }
                    
                
                    

                }
                

            }
            
        }
    }

    public void EnableTutorial()
    {
        isTutorialActive = true;
        TutText.text = TutDialogue[0];
        StartButtons.SetActive(false);

    }

    public void DisableTutorial()
    {
        isTutorialActive = false;
        TutorialPanel.SetActive(false);
    }

    
}
