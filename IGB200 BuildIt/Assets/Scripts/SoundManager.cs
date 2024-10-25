using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceButton;
    
    public AudioClip buySound;
    public AudioClip buttonClickSound;
    public Button[] shopButton;
    
    void Update()
    {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in shopButton)
        {
            button.onClick.AddListener(PurchaseSound);
        }
        
        foreach (Button button in buttons)
        {
            //make sure selling won't play this sound
            
            button.onClick.AddListener(PlayButtonSound);
            
        }
        
    }

    
    private void PlayButtonSound()
    {
        //just to make sure sound doesn't overlap when we click too fast.
        if(!audioSourceButton.isPlaying)
        {
            audioSourceButton.PlayOneShot(buttonClickSound);
        }
    }
    
    private void PurchaseSound()
    {
        if(!audioSourceButton.isPlaying)
        {
            audioSourceButton.PlayOneShot(buySound);
        }
    }

}
