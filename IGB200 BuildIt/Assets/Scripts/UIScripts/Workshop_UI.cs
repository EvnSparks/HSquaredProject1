using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Workshop_UI : MonoBehaviour
{
    public GameObject[] CanvasList;
    // 0 = Workshop UI
    // 1 = Shop Selector
    // 2 = Start Window


    public void Gamestart()
    {
        SceneManager.LoadScene("SampleScene");
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
}
