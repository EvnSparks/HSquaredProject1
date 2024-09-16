using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSellSystem : MonoBehaviour
{
    public GameObject[] gameObjects;

    public GameObject sellableObect;
    public GameObject itemStatViewer;
    public GameObject invetory;

    private bool itemSelling = false;

    // Selling Item System
    public void OnHover()
    {
        itemStatViewer.SetActive(true);
    }

    public void LeaveHover()
    {
        if (itemSelling) 
        {
            itemStatViewer.SetActive(true);
        }
        else
        {
            itemStatViewer.SetActive(false);
        }
    }

    public void Selling()
    {
        itemSelling = true;
    }

    public void ExitSellItem()
    {
        gameObjects[0].SetActive(true);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(false);

        if (itemSelling) 
        {
            itemSelling = false;
            itemStatViewer.SetActive(false);
        }
    }
}
