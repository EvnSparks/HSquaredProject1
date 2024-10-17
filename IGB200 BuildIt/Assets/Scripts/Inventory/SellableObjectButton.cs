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
    private float precisionScoreVisible; // rounded, only used for display
    public float timeScore;
    private float timeScoreVisible; // rounded, only used for display
    public float basePrice;
    public string material;

    public int inventoryReference;

    public InventoryItem item;

    private float sellPrice;
    private int activeShop;

    // GUI Variables
    public GameObject itemViewerGUI;
    public GameObject sellButton;
    public SellButton sellScript;

    // Updates text name of object
    private void Start()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = objectName;
        precisionScoreVisible = Mathf.Round(precisionScore);
        timeScoreVisible = Mathf.Round(timeScore);
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
                sellPrice = Mathf.Round(basePrice * precisionScoreVisible);
            }
            else
            {
                // Calc for time Shop
                sellPrice = basePrice * timeScoreVisible;
            }
                
            // Update all the values in the window
            itemViewerGUI.transform.Find("ItemDesc").GetComponent<TextMeshProUGUI>().text = objectName;
            itemViewerGUI.transform.Find("ItemVariables/PrecisionScore").GetComponent<TextMeshProUGUI>().text =
                "Precision Score: " + precisionScoreVisible.ToString() + "/5";
            itemViewerGUI.transform.Find("ItemVariables/TimeScore").GetComponent<TextMeshProUGUI>().text =
                "Time Score: " + timeScoreVisible.ToString() + "/5";
            itemViewerGUI.transform.Find("ItemVariables/Material").GetComponent<TextMeshProUGUI>().text =
                "Material: " + material.ToString();
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

        // Prevent going into negatives
        if (inventoryReference != 0)
        {
            GameManager.instance.inventory.RemoveAt(inventoryReference - GameManager.instance.itemrefmodifier);
            GameManager.instance.itemrefmodifier += 1;
        }
        else
        {
            GameManager.instance.inventory.RemoveAt(inventoryReference);
        }

        Destroy(gameObject);
        itemViewerGUI.SetActive(false);
        GameManager.instance.shopItemSelected = false;
    }
}
