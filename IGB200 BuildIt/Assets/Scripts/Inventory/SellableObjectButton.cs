using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SellableObjectButton : MonoBehaviour
{
    // Object Variables
    public string objectName;
    public float precisionScore;
    public float timeScore;
    public float basePrice;

    private float sellPrice;
    private float buyPrice;
    private int activeShop;

    // GUI Variables
    public GameObject itemViewerGUI;
    public GameObject sellButton;
    public SellButton sellScript;

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
        sellScript.sellObject = gameObject.GetComponent<SellableObjectButton>();
    }

    public void Sell()
    {
        GameManager.instance.money += sellPrice;
        Destroy(gameObject);
        itemViewerGUI.SetActive(false);
        GameManager.instance.shopItemSelected = false;
    }

}
