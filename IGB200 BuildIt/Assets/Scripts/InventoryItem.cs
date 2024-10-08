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
    public float materialCost;
    public ProjectType projectType;
    
    public InventoryItem(float accuracyRating, float materialCost, ProjectType projectType)
    {
        //this.item = item;
        this.accuracyRating = accuracyRating;
        this.materialCost = materialCost;
        this.projectType = projectType;
    }
}
