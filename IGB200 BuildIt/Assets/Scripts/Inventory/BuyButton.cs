using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
   public BuyObjectButton buyObject;

   //how many player is buying variables
    public TMP_Text HowMany;
    public int buyAmount = 0;

    void Update()
    {
        HowMany.text = "Amount Buying: " + buyAmount;
    }

   public void BuyObject()
   {
        int i;
        //make sure player has enough money
        if(GameManager.instance.money > buyAmount * buyObject.basePrice)
        {
            for(i=0;i<buyAmount;i++)
            {
                buyObject.Buy();
            }
        }
        //else just print like a prompt say you cannot buy. I lazy do now
        
        
   }
   public void increasebuy()
    {
        buyAmount+=1;
        
    }

    public void decreasebuy()
    {
        if(buyAmount <0)
        {
           buyAmount-=1; 
        }
        
    }
}
