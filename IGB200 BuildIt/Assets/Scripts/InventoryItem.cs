using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public enum ProjectType
    {
        Plank,
        Sign,
        Table
    }
    
    //public GameObject item;
    public float accuracyRating;
    public float speedRating;
    public float predictedProfit;
    public GameManager.Material materialQuality;
    public ProjectType projectType;
    
    public InventoryItem(float accuracyRating, float timeTaken, float materialCost, GameManager.Material materialQuality, ProjectType projectType)
    {
        //this.item = item;
        this.accuracyRating = accuracyRating;
        this.projectType = projectType;
        this.materialQuality = materialQuality;
        this.speedRating = Mathf.Max(5-(timeTaken/60), 1); 
        this.predictedProfit = GameManager.instance.materialInventory[(int)GameManager.instance.materialselected].costMultiplier * ((int)GameManager.instance.projectType + 1) * (accuracyRating + this.speedRating) / 2;
    }
}
