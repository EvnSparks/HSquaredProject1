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

    // ItemTracker
    private int materialReference;

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
            // An unglamorous way to code this in but it'll work...
            if (objectName == "Low Quality")
            {
                materialReference = 0;
            }
            if (objectName == "Med Quality")
            {
                materialReference = 1;
            }
            if (objectName == "High Quality")
            {
                materialReference = 2;
            }

            // Set up GUI
            itemViewerGUI.SetActive(true);

            // Update all the values in the window
            itemViewerGUI.transform.Find("MaterialName").GetComponent<TextMeshProUGUI>().text = objectName;
            itemViewerGUI.transform.Find("ItemVariables/Text/Price").GetComponent<TextMeshProUGUI>().text =
                "Buy Cost: $" + buyPrice.ToString();
            itemViewerGUI.transform.Find("ItemVariables/Text/In_Inventory").GetComponent<TextMeshProUGUI>().text = "In-Inventory: " +
                GameManager.instance.materialInventory[materialReference].inventoryAmount.ToString();
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

        
    // This button basically just closes the itemviewgui to reset it.
    public void Buy()
    {
        itemViewerGUI.SetActive(false);
        GameManager.instance.shopItemSelected = false;
    }
}
