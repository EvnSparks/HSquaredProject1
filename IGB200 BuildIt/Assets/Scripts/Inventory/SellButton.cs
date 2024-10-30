using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SellButton : MonoBehaviour
{
    public SellableObjectButton sellObject;
    public Button sellButton;

    public AudioSource audioSourceButton;

    public AudioClip sellSound;

    public void SellObject()
    {
        sellObject.Sell();
        audioSourceButton.PlayOneShot(sellSound);
    }

}
