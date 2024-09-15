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
    // 5 Dialogue Talk Active

    // Keeps track of active shop
    private int ActiveShop;
    public Dialogue dialogueScript;

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

    public void ShopEnter2()
    {
        CanvasList[1].SetActive(false);
        CanvasList[3].SetActive(true);

        ActiveShop = 3;
    }

    public void ShopEnter3()
    {
        CanvasList[1].SetActive(false);
        CanvasList[4].SetActive(true);

        ActiveShop = 4;
    }

    public void ShopDialogue()
    {
        CanvasList[5].SetActive(true);
        
        // ActiveShop - 1 has to be done to keep it in line with actual shop values in dialogue script
        dialogueScript.StartDialogue(ActiveShop - 1);
    }

    public void ShopExit()
    {
        CanvasList[1].SetActive(true);
        CanvasList[ActiveShop].SetActive(false);
    }
}
