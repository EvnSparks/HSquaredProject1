using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyObjectButton : MonoBehaviour
{
    // Object Variables
    public string objectName;
    public string objectDescription;
    public float buyPrice = 0;

    // GUI Variables
    public GameObject itemViewerGUI;
    public GameObject buyButton;
    public BuyButton buyScript;

    // Updates text name of object
    private void Start()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = objectName;
    }

    // Button Interactions
    public void OnHover()
    {
        if (!GameManager.instance.shopItemSelected)
        {
            // Set up GUI
            itemViewerGUI.SetActive(true);

            // Update all the values in the window
            itemViewerGUI.transform.Find("MaterialName").GetComponent<TextMeshProUGUI>().text = objectName;
            itemViewerGUI.transform.Find("ItemVariables/Text/Price").GetComponent<TextMeshProUGUI>().text =
                "Buy Cost: $" + buyPrice.ToString();
        }
    }

    public void LeaveHover()
    {
        if (!GameManager.instance.shopItemSelected)
        {
            itemViewerGUI.SetActive(false);
        }
    }

    public void OnClick()
    {
        GameManager.instance.shopItemSelected = true;
        buyScript.buyObject = gameObject.GetComponent<BuyObjectButton>();
    }


    //Changes here
    public void Buy()
    {
        //Make sure player has enough to buy item
        if(GameManager.instance.money > buyPrice)
        {
            GameManager.instance.money -= buyPrice;
            itemViewerGUI.SetActive(false);
            GameManager.instance.shopItemSelected = false;
        }
    }
}