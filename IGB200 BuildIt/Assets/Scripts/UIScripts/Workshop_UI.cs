using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Workshop_UI : MonoBehaviour
{

    public GameObject[] CanvasList;

    //  Relates to buttons in WorkshopUI
    public void Gamestart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Relates to buttons in ShopUI
    public void ShopSelector() 
    {
        CanvasList[1].SetActive(true);
        CanvasList[0].SetActive(false);
    }

    public void ExitShopSelector()
    {
        CanvasList[1].SetActive(false);
        CanvasList[0].SetActive(true);
    }
}
