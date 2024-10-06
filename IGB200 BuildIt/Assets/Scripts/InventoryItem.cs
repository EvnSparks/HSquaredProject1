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
    
    public GameObject item;
    public float accuracyRating;
    public ProjectType projectType;

    public InventoryItem(GameObject item, float accuracyRating, ProjectType projectType)
    {
        this.item = item;
        this.accuracyRating = accuracyRating;
        this.projectType = projectType;
    }
}
