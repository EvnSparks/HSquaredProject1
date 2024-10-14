using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Workshop_UI : MonoBehaviour
{
    private bool Mat1Selected, Mat2Selected,Mat3Selected;
    private TMP_Text DescTitle, Desc;

    public Tutorial tutorial;
    
    public GameObject HeaderD, DescD;

    public GameObject[] CanvasList;
    // 0 = Workshop UI
    // 1 = Shop Selector
    // 2 = Start Window

    void Start()
    {
        // Part of tutorial script will be commented out until time can be found to fix and integrate it properly

        //DescTitle = HeaderD.GetComponent<TMP_Text>();
        //Desc = DescD.GetComponent<TMP_Text>();
    }

    void Update()
    {
        //if selected bring up description
        // There is probably a better way to do this without breaking how workshop_UI works atm...
        // I will comment this out until we can get it working properly. - Evan
        /*
        if(Mat1Selected || Mat2Selected || Mat3Selected)
        {
            CanvasList[4].SetActive(true);
            if(Mat1Selected)
            {
                DescTitle.text = "Item1";
                Desc.text = "Standard wood, popular among the average consumer";
            }
            if(Mat2Selected)
            {
                DescTitle.text = "Item2";
                Desc.text = "Decent wood, used for mid-tier furniture";
            }
            if(Mat3Selected)
            {
                DescTitle.text = "Item3";
                Desc.text = "This is top quality wood, looked for by collectors";
            }
        }
        else
        {
            // Activates the Material Selector Menu
            CanvasList[4].SetActive(false);
        }
        */
    }
    public void Gamestart()
    {
        SceneManager.LoadScene("SampleScene");

        // Part of tutorial code that is throwing out errors in current workshop implementation
        /*
        if(tutorial.DialogueIndex == 16)
        {
            tutorial.isTutorialActive = false;
            tutorial.isTutorialCompleted = true;
        }
        if(Mat1Selected || Mat2Selected || Mat3Selected)
        {
            SceneManager.LoadScene("SampleScene");
        }
        */
    }

    public void StartWindow()
    {
        CanvasList[2].SetActive(true);

        /*
        if(tutorial.DialogueIndex == 12)
        {
            tutorial.IndexClick();
        }
        */

    }
 
    public void ExitStartWindow()
    {
        CanvasList[2].SetActive(false);
    }

    // Relates to buttons in ShopUI
    public void ShopSelector()
    {
        CanvasList[1].SetActive(true);
        CanvasList[0].SetActive(false);
        CanvasList[2].SetActive(false);

        /*
        if(tutorial.DialogueIndex ==3)
        {
            tutorial.IndexClick();
        }
        */
    }

    public void ExitShopSelector()
    {
        CanvasList[0].SetActive(true);
        CanvasList[1].SetActive(false);
        CanvasList[2].SetActive(false);

        /*
        if(tutorial.DialogueIndex == 11)
        {
            tutorial.IndexClick();
        }
        */
    }

    public void SelectMatwindow()
    {
        CanvasList[3].SetActive(true);

        /*
        if(tutorial.DialogueIndex == 13)
        {
            tutorial.IndexClick();
        }
        */
    }

    public void ExitSelectMat()
    {
        CanvasList[3].SetActive(false);
    }

    public void SelectMat1()
    {
        Mat1Selected = true;
        Mat2Selected = false;
        Mat3Selected = false;

        if(tutorial.DialogueIndex == 14)
        {
            tutorial.IndexClick();
        }
    }

    public void SelectMat2()
    {
        Mat1Selected = false;
        Mat2Selected = true;
        Mat3Selected = false;
    }

    public void SelectMat3()
    {
        Mat1Selected = false;
        Mat2Selected = false;
        Mat3Selected = true;
    }

    public void ExitDescription()
    {
        Mat1Selected = false;
        Mat2Selected = false;
        Mat3Selected = false;
    }

}
