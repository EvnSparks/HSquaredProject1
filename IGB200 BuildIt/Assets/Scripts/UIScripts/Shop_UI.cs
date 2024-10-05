using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_UI : MonoBehaviour
{
    //Stores Scenes to turn on and Off
    public GameObject[] ShopUI;

    //Stores triggers 
    public DialogueTrigger Talk;
    public DialogueTrigger SpecialQuest;
    public DialogueTrigger Sell;

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
        ShopUI[1].SetActive(true);
    }
}
