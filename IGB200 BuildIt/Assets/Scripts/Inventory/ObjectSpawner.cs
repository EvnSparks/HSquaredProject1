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

    public float objectCount = 3;

    // This works for the moment, need to edit this to combine with the inventory system later

    private void Start()
    {
        for (int i = 0; i < objectCount; i++) 
        {
            craftedObject.GetComponent<SellableObjectButton>().itemViewerGUI = itemViewerGUI;
            craftedObject.GetComponent<SellableObjectButton>().sellButton = sellButton;
            craftedObject.GetComponent<SellableObjectButton>().sellScript = sellScript;

            craftedObject.GetComponent<SellableObjectButton>().objectName = "Plank " + i.ToString();
            craftedObject.GetComponent<SellableObjectButton>().precisionScore = Random.Range(1, 5);
            craftedObject.GetComponent<SellableObjectButton>().timeScore = Random.Range(1, 5);
            craftedObject.GetComponent<SellableObjectButton>().basePrice = 3;

            Instantiate(craftedObject, this.transform);
        }
    }
}
