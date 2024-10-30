using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource audioSourceButton;
    
    public AudioClip buySound;
    public AudioClip buttonClickSound;
    public Button[] shopButton;

    public bool isBuySound;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    void Update()
    {
        if (!isBuySound)
        {
            Button[] buttons = FindObjectsOfType<Button>();

            foreach (Button button in buttons)
            {
                //make sure selling won't play this sound

                button.onClick.AddListener(PlayButtonSound);

            }
        }
        else
        {
            foreach (Button button in shopButton)
            {
                button.onClick.AddListener(PurchaseSound);
            }
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
