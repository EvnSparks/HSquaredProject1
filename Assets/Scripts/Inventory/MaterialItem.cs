using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialItem
{
    public string name;
    public float materialCost;
    public float costMultiplier;
    public int inventoryAmount;
    // Material Texture Variable?

    public MaterialItem(string materialname, float materialCost, float costMultiplier, int inventoryAmount)
    {
        this.name = materialname;
        this.materialCost = materialCost;
        this.costMultiplier = costMultiplier;
        this.inventoryAmount = inventoryAmount;
    }
}
