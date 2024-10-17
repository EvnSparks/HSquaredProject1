using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //public List<GameObject> Inventory = GameManager.instance.inventory;
    
    public GameObject craftedObject;

    // GUI Variables
    public GameObject itemViewerGUI;
    public GameObject sellButton;
    public SellButton sellScript;

    // Inventory reference number
    private int inventoryReference;

    // This works for the moment, need to edit this to combine with the inventory system later

    private void Start()
    {
        // Reset reference number
        inventoryReference = 0;
        GameManager.instance.itemrefmodifier = 0;

        SellableObjectButton objectSettings = craftedObject.GetComponent<SellableObjectButton>();
        objectSettings.itemViewerGUI = itemViewerGUI;
        objectSettings.sellButton = sellButton;
        objectSettings.sellScript = sellScript;
        foreach (InventoryItem item in GameManager.instance.inventory)
        {
            objectSettings.objectName = item.projectType.ToString();
            objectSettings.precisionScore = item.accuracyRating;
            objectSettings.timeScore = item.speedRating;
            objectSettings.basePrice = GameManager.instance.materialInventory[(int)item.materialQuality].costMultiplier * ((int)GameManager.instance.projectType + 1);
            objectSettings.material = item.materialQuality.ToString();
            
            objectSettings.inventoryReference = inventoryReference;
            inventoryReference++;

            // Works here but does not carry over for some reason??? - Evan
            //objectSettings.item = item;

            Instantiate(craftedObject, this.transform);
        }
    }
}
