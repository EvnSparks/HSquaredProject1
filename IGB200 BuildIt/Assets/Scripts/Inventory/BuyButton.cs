using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{

   public BuyObjectButton buyObject;
   public TMP_Text amountText;
   public int buyAmount = 0;

   private int materialReference;

   public void BuyObject()
   {
        // Compare player money and amount needing to be paid
        if (GameManager.instance.money >= (buyAmount * buyObject.buyPrice))
        {
            GameManager.instance.money -= buyAmount * buyObject.buyPrice;

            // An unglamorous way to code this in but it'll work...
            if (buyObject.objectName == "Low Quality")
            {
                materialReference = 0;
            }
            if (buyObject.objectName == "Med Quality")
            {
                materialReference = 1;
            }
            if (buyObject.objectName == "High Quality")
            {
                materialReference = 2;
            }

            GameManager.instance.materialInventory[materialReference].inventoryAmount += buyAmount;
            buyObject.Buy();
        }
   }

   public void IncreaseAmount()
    {
        // Prevents amount being increased passed a certain amount
        if (buyAmount < 99)
        {
            buyAmount += 1;
            amountText.text = "Amount Buying: " + buyAmount;
        }

    }

    public void DecreaseAmount()
    {
        // Prvents the player from printing free money... 0_0
        if(buyAmount > 0)
        {
           buyAmount -= 1;
           amountText.text = "Amount Buying: " + buyAmount;
        }
        
    }
}
