using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public enum ProjectType
    {
        Plank,
        Table,
        Chair, // likely unused
        Cabinet // likely unused
    }
    
    //public GameObject item;
    public float accuracyRating;
    public float speedRating;
    public float materialCost;
    public int materialQuality = 1;
    public ProjectType projectType;
    
    public InventoryItem(float accuracyRating, float timeTaken, float materialCost, int materialQuality, ProjectType projectType)
    {
        //this.item = item;
        this.accuracyRating = accuracyRating;
        this.materialCost = materialCost;
        this.projectType = projectType;
        this.speedRating = Mathf.Min(5-(timeTaken/60), 1);
    }
}
