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

    // This works for the moment, need to edit this to combine with the inventory system later

    private void Start()
    {
        SellableObjectButton objectSettings = craftedObject.GetComponent<SellableObjectButton>();
        objectSettings.itemViewerGUI = itemViewerGUI;
        objectSettings.sellButton = sellButton;
        objectSettings.sellScript = sellScript;
        foreach (InventoryItem item in GameManager.instance.inventory)
        {
            objectSettings.objectName = item.projectType.ToString();
            objectSettings.precisionScore = item.accuracyRating;
            objectSettings.timeScore = Random.Range(1, 5);
            objectSettings.basePrice = 3;

            Instantiate(craftedObject, this.transform);
        }
    }
}
