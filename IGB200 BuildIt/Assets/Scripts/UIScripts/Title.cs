using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Title : MonoBehaviour
{
    public TextMeshProUGUI title;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.quest1complete)
        {
            title.text = "Title: Trainee Carpenter";
        }
        if (GameManager.instance.quest2complete)
        {
            title.text = "Title: Intermediate Carpenter";
        }
        if (GameManager.instance.quest3complete)
        {
            title.text = "Title: Apprentice";
        }
    }
}
