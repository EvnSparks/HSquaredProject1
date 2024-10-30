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
        //sellButton.onClick.AddListener(PlayButtonSound);
    }

    private void PlayButtonSound()
    {
        //just to make sure sound doesn't overlap when we click too fast.
        if (!audioSourceButton.isPlaying)
        {
            audioSourceButton.PlayOneShot(sellSound);
        }
    }
}
