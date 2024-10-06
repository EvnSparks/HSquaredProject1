using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop_Navigator : MonoBehaviour
{
    //Stores Scenes to turn on and Off
    public GameObject[] ShopScenes;

    // Keeps track of active shop
    private int activeShop;
    public DialogueTrigger dialogueScript;

    // Button Options
    public void EnterShop1()
    {
        activeShop = 1;
        GameManager.instance.activeShop = activeShop;
        ShopOpen();
    }

    public void EnterShop2()
    {
        activeShop = 2;
        GameManager.instance.activeShop = activeShop;
        ShopOpen();
    }

    public void EnterShop3()
    {
        activeShop = 3;
        GameManager.instance.activeShop = activeShop;
        ShopOpen();
    }

    public void ShopExit()
    {
        ShopScenes[0].SetActive(true);
        ShopScenes[activeShop].SetActive(false);
        ShopScenes[4].SetActive(false);
    }

    // Repeat Button Functions
    void ShopOpen()
    {
        ShopScenes[0].SetActive(false);
        ShopScenes[activeShop].SetActive(true);
        dialogueScript.ShopWelcome(activeShop);
    }
}
