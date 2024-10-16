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
            // Establish Consistent variables to spawn
            craftedObject.GetComponent<BuyObjectButton>().itemViewerGUI = itemViewerGUI;
            craftedObject.GetComponent<BuyObjectButton>().buyButton = buyButton;
            craftedObject.GetComponent<BuyObjectButton>().buyScript = buyScript;

            Material_1();
            Material_2();
            Material_3();
        }

        //Low Quality Material
        private void Material_1()
        {
            craftedObject.GetComponent<BuyObjectButton>().objectName = "Low Quality";
            craftedObject.GetComponent<BuyObjectButton>().buyPrice = 5;

            Instantiate(craftedObject,this.transform);
        }

        //Medium Quality Material
        private void Material_2()
        {
            craftedObject.GetComponent<BuyObjectButton>().objectName = "Med Quality";
            craftedObject.GetComponent<BuyObjectButton>().buyPrice = 10;
            Instantiate(craftedObject,this.transform);
        }

        //High Quality Material

        private void Material_3()
        {
            craftedObject.GetComponent<BuyObjectButton>().objectName = "High Quality";
            craftedObject.GetComponent<BuyObjectButton>().buyPrice = 15;
            Instantiate(craftedObject, this.transform);
        }
}
