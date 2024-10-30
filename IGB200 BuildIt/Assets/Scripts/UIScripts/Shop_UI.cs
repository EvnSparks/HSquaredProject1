using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_UI : MonoBehaviour
{
    //Stores Scenes to turn on and Off
    public GameObject[] ShopUI;

    //Stores triggers 
    public DialogueTrigger Talk;
    public DialogueTriggerQuest SpecialQuest;
    public DialogueTrigger Sell;

    // Object Spawner Script
    public ObjectSpawner Spawner;

    public void ShopTalk()
    {
        Talk.TriggerDialogue();
    }

    public void QuestTalk()
    {
        SpecialQuest.TriggerDialogue();
    }

    public void SellTalk()
    {
        Sell.TriggerDialogue();

        // Set active inventory menu
        ShopUI[1].SetActive(true);
    }

    public void ExitInvetory()
    {
        ShopUI[1].SetActive(false);
        ShopUI[3].SetActive(false);
        ShopUI[0].SetActive(true);
        ShopUI[2].SetActive(false);

        // Reset Shop Item Selected Variable
        GameManager.instance.shopItemSelected = false;

        DialogueManager.Instance.isDialogueActive = false;
    }

    public void ExitItemViewer()
    {
        // Item view lock = false
        ShopUI[2].SetActive(false);
        GameManager.instance.shopItemSelected = false;
    }
}
