using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceButton;
    
    //don't think we need this we're just playing music on loop
    //public AudioSource audioSourceMusic;
    public AudioClip buttonClickSound;
    // void Start()
    // {
    //     //assign all buttons to make sound
    //     Button[] buttons = FindObjectsOfType<Button>();
        
    //     foreach (Button button in buttons)
    //     {
    //         button.onClick.AddListener(PlayButtonSound);
    //     }
    // }
    
    void Update()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayButtonSound);
        }
    }

    // Update is called once per frame
    private void PlayButtonSound()
    {
        //just to make sure sound doesn't overlap when we click too fast.
        if(!audioSourceButton.isPlaying)
        {
            audioSourceButton.PlayOneShot(buttonClickSound);
        }
    }
    
}
