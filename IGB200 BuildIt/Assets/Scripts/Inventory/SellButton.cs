using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SellButton : MonoBehaviour
{
    public SellableObjectButton sellObject;

    public void SellObject()
    {
        sellObject.Sell();
    }
}
