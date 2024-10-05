using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private float currentlyDisplayMoney = 0;
    public TextMeshProUGUI textArea;

    void Awake()
    {
        currentlyDisplayMoney = GameManager.instance.money;
        textArea.text = "$" + GameManager.instance.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyDisplayMoney != GameManager.instance.money)
        {
            textArea.text = "$" + GameManager.instance.money.ToString();
            currentlyDisplayMoney = GameManager.instance.money;
        }
    }
}
