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
    

    public GameObject[] CanvasList;
    // 0 = Workshop UI
    // 1 = Shop Selector
    // 2 = Start Window

    void Start()
    {
        GameObject HeaderD = GameObject.Find("DescriptionHeader");
        GameObject DescD = GameObject.Find("DescriptionText");
        DescTitle = HeaderD.GetComponent<TMP_Text>();
        Desc = DescD.GetComponent<TMP_Text>();
    }

    void Update()
    {
        //if selected bring up description
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
            CanvasList[4].SetActive(false);
        }
    }
    public void Gamestart()
    {
        if(Mat1Selected || Mat2Selected || Mat3Selected)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void StartWindow()
    {
        CanvasList[2].SetActive(true);
        
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
    }

    public void ExitShopSelector()
    {
        CanvasList[0].SetActive(true);
        CanvasList[1].SetActive(false);
        CanvasList[2].SetActive(false);
    }

    public void SelectMatwindow()
    {
        CanvasList[3].SetActive(true);
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
