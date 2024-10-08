using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{

   public BuyObjectButton buyObject;
   public TMP_Text amountText;
   public int buyAmount = 0;

   public void BuyObject()
   {
        // Compare player money and amount needing to be paid
        if (GameManager.instance.money > (buyAmount * buyObject.buyPrice))
        {
            // Pass the amount being bought to the button
            // Activate the buy part of the button
        }



        int i;

        //make sure player has enough money
        if(GameManager.instance.money > buyAmount * buyObject.buyPrice)
        {
            for(i=0;i<buyAmount;i++)
            {
                buyObject.Buy();
            }
        }
        //else just print like a prompt say you cannot buy. I lazy do now
        
            
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
<<<<<<< HEAD
=======
        // Prvents the player from printing free money... 0_0
>>>>>>> main
        if(buyAmount > 0)
        {
           buyAmount -= 1;
           amountText.text = "Amount Buying: " + buyAmount;
        }
        
    }
}
