using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableBP : MonoBehaviour
{
    public GameObject bp2;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.quest1complete)
        {
            bp2.GetComponent<Button>().interactable = false;
        }
        else
        {
            bp2.GetComponent<Button>().interactable = true;
        }
    }
}
