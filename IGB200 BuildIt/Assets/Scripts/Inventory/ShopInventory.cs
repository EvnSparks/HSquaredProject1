using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    //Stealing your code to make the shop UI

        // Start is called before the first frame update
        public GameObject craftedObject;
        // GUI Variables
        public GameObject itemViewerGUI;
        public GameObject buyButton;
        public BuyButton buyScript;
        public float objectCount = 3;

        // This works for the moment, need to edit this to combine with the inventory system later

        private void Start()
        {
            // for (int i = 0; i < objectCount; i++) 
            // {
            //     craftedObject.GetComponent<SellableObjectButton>().itemViewerGUI = itemViewerGUI;
            //     craftedObject.GetComponent<SellableObjectButton>().sellButton = buyButton;
            //     //craftedObject.GetComponent<SellableObjectButton>().sellScript = sellScript;

            //     craftedObject.GetComponent<SellableObjectButton>().objectName = "Plank " + i.ToString();
            //     craftedObject.GetComponent<SellableObjectButton>().precisionScore = Random.Range(1, 5);
            //     craftedObject.GetComponent<SellableObjectButton>().timeScore = Random.Range(1, 5);
            //     craftedObject.GetComponent<SellableObjectButton>().basePrice = 3;

            //     Instantiate(craftedObject, this.transform);
            // }
           
           Item01();
           Item02();
        }

        //Since your snapping already works, I'll just add items for the shop like this. So every new item here will just be added to the

        //Raw Wood Plank
        private void Item01()
        {
            Instantiate(craftedObject,this.transform);
            craftedObject.GetComponent<BuyObjectButton>().itemViewerGUI = itemViewerGUI;
            craftedObject.GetComponent<BuyObjectButton>().buyButton = buyButton;
            craftedObject.GetComponent<BuyObjectButton>().buyScript = buyScript;

            craftedObject.GetComponent<BuyObjectButton>().objectName = "Wood Block";
            craftedObject.GetComponent<BuyObjectButton>().buyPrice = 3;


            //Instantiate(craftedObject,this.transform);
        }

        //Nails
        private void Item02()
        {
            Instantiate(craftedObject,this.transform);
            craftedObject.GetComponent<BuyObjectButton>().itemViewerGUI = itemViewerGUI;
            craftedObject.GetComponent<BuyObjectButton>().buyButton = buyButton;
            craftedObject.GetComponent<BuyObjectButton>().buyScript = buyScript;

            craftedObject.GetComponent<BuyObjectButton>().objectName = "Nail";
            craftedObject.GetComponent<BuyObjectButton>().buyPrice = 7;
            //Instantiate(craftedObject,this.transform);
        }
}
