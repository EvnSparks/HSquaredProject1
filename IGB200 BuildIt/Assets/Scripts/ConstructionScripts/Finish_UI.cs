﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Finish_UI : MonoBehaviour
{
    public AudioClip starSound;
    public AudioSource SoundPlayer;
    private bool escapeMenuActive = false;
    private InventoryItem item;
    
    //Display settings
    [SerializeField]
    private float[] waitTime = new float[3];
    [SerializeField]
    private TMP_Text tmp;
    [SerializeField]
    private Stars[] accStars = new Stars[5];
    [SerializeField]
    private Stars[] speedStars = new Stars[5];
    private string originalText;

    private void Awake()
    {
        originalText = tmp.text; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escapeMenuActive == true)
        {
            this.gameObject.SetActive(false);
            escapeMenuActive = false;
        }
    }

    public void Resume()
    {
        tmp.text = originalText;
        foreach (Stars star in accStars) star.Hide();
        foreach (Stars star in speedStars) star.Hide();
        this.gameObject.SetActive(false);
        escapeMenuActive = false;
        
    }

    public void MainMenu()
    {
        GameManager.instance.inventory.Add(item);
        
        // Add to quest tracker based on the following
        if (item.accuracyRating >= 4.5 && item.projectType == InventoryItem.ProjectType.Plank)
        {
            GameManager.instance.fiveStarPlanksCount++;
        }
        else if (GameManager.instance.questactive == 2 && item.accuracyRating >= 2.5 && item.projectType == InventoryItem.ProjectType.Sign && (item.materialQuality == GameManager.Material.medQuality || item.materialQuality == GameManager.Material.highQuality))
        {
            GameManager.instance.threeStarSignCount++;
        }

        // Adjusts inventory amount of material based on object and material type
        if (GameManager.instance.projectType == InventoryItem.ProjectType.Plank)
        {
            GameManager.instance.materialInventory[((int)GameManager.instance.materialselected)].inventoryAmount -= 1;
        }
        else if (GameManager.instance.projectType == InventoryItem.ProjectType.Sign)
        {
            GameManager.instance.materialInventory[((int)GameManager.instance.materialselected)].inventoryAmount -= 2;
        }
        else if (GameManager.instance.projectType == InventoryItem.ProjectType.Table)
        {
            GameManager.instance.materialInventory[((int)GameManager.instance.materialselected)].inventoryAmount -= 3;
        }

        SceneManager.LoadScene("WorkShop");
    }

    
    public void ShowMenu(InventoryItem item)
    {
        this.gameObject.SetActive(true);
        escapeMenuActive = true;
        this.item = item;
        
        // display results
        StartCoroutine(ShowResults());
    }
    private IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(waitTime[0]);
        for (int i = 0; i < Mathf.Round(item.accuracyRating); i++)
        {
            accStars[i].Spawn();
            //add SFX here
            SoundPlayer.PlayOneShot(starSound);
            yield return new WaitForSeconds(waitTime[1]);
        }
        yield return new WaitForSeconds(waitTime[0]);
        for (int i = 0; i < Mathf.Round(item.speedRating); i++)
        {
            speedStars[i].Spawn();
            // add SFX here
            SoundPlayer.PlayOneShot(starSound);
            yield return new WaitForSeconds(waitTime[1]);
        }
        yield return new WaitForSeconds(waitTime[0]);
        
        float cost = 0;
        for (int i = 0; i < item.predictedProfit; i++)
        {
            cost++;
            tmp.text = originalText + cost.ToString();
            yield return new WaitForSeconds(waitTime[2]);
        }
    }
}
