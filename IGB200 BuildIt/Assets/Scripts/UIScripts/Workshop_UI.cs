using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Workshop_UI : MonoBehaviour
{
    // Doing this to get Canvas References even if disabled... - Evan
    public GameObject[] CanvasList;
    // 0 = WorkshopUI
    // 1 = ShopUI
    // 2 - 4 = Shop 1 - 3
    // 5 - 7 = Shop Dialogue Active

    // Keeps track of active shop
    private int ActiveShop;

    //  Relates to buttons in WorkshopUI
    public void Gamestart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Relates to buttons in ShopUI
    public void Shop() 
    {
        CanvasList[1].SetActive(true);
        CanvasList[0].SetActive(false);
    }

    public void ExitShopSelector()
    {
        CanvasList[1].SetActive(false);
        CanvasList[0].SetActive(true);
    }

    // Thinking there is a better way than repeating shop 1-3 but ittttt works for now and our game doesn't need this to scale for now... - Evan
    public void ShopEnter1()
    {
        CanvasList[1].SetActive(false);
        CanvasList[2].SetActive(true);

        ActiveShop = 2;
    }

    public void ShopDialogue1()
    {
        CanvasList[5].SetActive(true);
    }

    public void ShopEnter2()
    {
        CanvasList[1].SetActive(false);
        CanvasList[3].SetActive(true);

        ActiveShop = 3;
    }

    public void ShopDialogue2()
    {
        CanvasList[6].SetActive(true);
    }

    public void ShopEnter3()
    {
        CanvasList[1].SetActive(false);
        CanvasList[4].SetActive(true);

        ActiveShop = 4;
    }

    public void ShopDialogue3()
    {
        CanvasList[7].SetActive(true);
    }

    public void ShopExit()
    {
        CanvasList[1].SetActive(true);
        CanvasList[ActiveShop].SetActive(false);
    }
}
