using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SellableObjectButton : MonoBehaviour
{
    // Object Variables
    public string objectName;
    public float precisionScore;
    public float timeScore;
    public float basePrice;

    private float sellPrice;
    private int activeShop;

    private bool itemSelected;

    // GUI Variables
    public GameObject itemViewerGUI;

    // Button Interactions
    public void OnHover()
    {
        // Set up GUI
        itemViewerGUI.SetActive(true);

        // Calculate Sell Price
        activeShop = GameManager.instance.activeShop;
        if (activeShop == 1)
        {
            // Calc for precision Shop
            sellPrice = basePrice * precisionScore;
        }
        else
        {
            // Calc for time Shop
            sellPrice = basePrice * timeScore;
        }

        // Update all the values in the window
        itemViewerGUI.transform.Find("ItemDesc").GetComponent<TextMeshProUGUI>().text = objectName;
        itemViewerGUI.transform.Find("ItemVariables/PrecisionScore").GetComponent<TextMeshProUGUI>().text =
            "Precision Score: " + precisionScore.ToString() + "/5";
        itemViewerGUI.transform.Find("ItemVariables/TimeScore").GetComponent<TextMeshProUGUI>().text =
            "Time Score: " + timeScore.ToString() + "/5";

        itemViewerGUI.transform.Find("ItemVariables/Price").GetComponent<TextMeshProUGUI>().text =
            "Sell Price: $" + sellPrice.ToString();
    }

    public void LeaveHover()
    {
        if (!itemSelected)
        {
            itemViewerGUI.SetActive(false);
        }
    }

    public void OnClick()
    {
        itemSelected = true;
        // Keep item viewer locked
            // Some sort of bool value
        // Prevent hover on working on any other object
            // Use game manager to lock inventory hover
    }

    public void Sell()
    {
        GameManager.instance.money += sellPrice;
    }

    public void ExitItemViewer()
    {
        // Item view lock = false
        itemViewerGUI.SetActive(false);
        itemSelected = false;
    }
}
