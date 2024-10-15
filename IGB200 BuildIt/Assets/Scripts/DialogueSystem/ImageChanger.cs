using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image npcImage;
    public Sprite[] Portraits;
    public DialogueManager DialogueManager;

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.isDialogueActive)
        {
            npcImage.sprite = Portraits[1];
        }
        else
        {
            npcImage.sprite = Portraits[0];
        }
    }
}
