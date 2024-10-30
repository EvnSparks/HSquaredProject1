using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Workshop_UI : MonoBehaviour
{
    //Variable to track selected blueprint and materials
    private bool Mat1Selected, Mat2Selected,Mat3Selected;
    private InventoryItem.ProjectType selectedProject;
    
    public Tutorial tutorial;

    // List of Material Text Variables
    public TextMeshProUGUI MaterialName;
    public TextMeshProUGUI MaterialDescription;
    public TextMeshProUGUI MaterialAmount;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI PotentialProfit1Star;
    public TextMeshProUGUI PotentialProfit5Stars;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI ErrorText;

    // List of Canvas Objects
    public GameObject[] CanvasList;
    // 0 = Workshop UI, 1 = Shop Selector, 2 = Select BP, 3 = Select Mat, 4 = Mat Description, 5 = Start Game

    void Update()
    {
        //if selected bring up description

        if(Mat1Selected || Mat2Selected || Mat3Selected)
        {
            CanvasList[4].SetActive(true);

            // The following is hard coded because I have lost all sanity... - Evan

            if(Mat1Selected)
            {
                MaterialName.text = "Low Quality Wood";
                MaterialDescription.text = "Standard wood, popular amongst the average consumer";

                // Set amounts based on object Selected
                ItemName.text = "Item Name: " + selectedProject.ToString();
                
                // Pass through material selected
                GameManager.instance.materialselected = GameManager.Material.lowQuality;

                if (selectedProject == InventoryItem.ProjectType.Plank)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[0].inventoryAmount.ToString() + "/ 1";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$3";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$15";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[0].materialCost * 1).ToString();
                }

                if (selectedProject == InventoryItem.ProjectType.Sign)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[0].inventoryAmount.ToString() + "/ 2";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$6";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$30";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[0].materialCost * 2).ToString();
                }

                if (selectedProject == InventoryItem.ProjectType.Table)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[0].inventoryAmount.ToString() + "/ 3";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$9";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$45";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[0].materialCost * 3).ToString();
                }
            }
            if(Mat2Selected)
            {
                MaterialName.text = "Medium Quality Wood";
                MaterialDescription.text = "Decent wood, used for mid-tier furniture";

                // Set amounts based on object Selected
                ItemName.text = "Item Name: " + selectedProject.ToString();

                // Pass through material selected
                GameManager.instance.materialselected = GameManager.Material.medQuality;

                if (selectedProject == InventoryItem.ProjectType.Plank)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[1].inventoryAmount.ToString() + "/ 1";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$6";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$30";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[1].materialCost * 1).ToString();
                }

                if (selectedProject == InventoryItem.ProjectType.Sign)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[1].inventoryAmount.ToString() + "/ 2";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$12";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$60";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[1].materialCost * 2).ToString();
                }

                if (selectedProject == InventoryItem.ProjectType.Table)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[1].inventoryAmount.ToString() + "/ 3";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$18";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$90";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[1].materialCost * 3).ToString();
                }
            }
            if(Mat3Selected)
            {
                MaterialName.text = "High Quality Wood";
                MaterialDescription.text = "This is top quality wood, looked for by collectors";

                // Set amounts based on object Selected
                ItemName.text = "Item Name: " + selectedProject.ToString();

                // Pass through material selected
                GameManager.instance.materialselected = GameManager.Material.highQuality;

                if (selectedProject == InventoryItem.ProjectType.Plank)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[2].inventoryAmount.ToString() + "/ 1";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$10";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$50";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[2].materialCost * 1).ToString();
                }

                if (selectedProject == InventoryItem.ProjectType.Sign)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[2].inventoryAmount.ToString() + "/ 2";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$20";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$100";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[2].materialCost * 2).ToString();
                }

                if (selectedProject == InventoryItem.ProjectType.Table)
                {
                    MaterialAmount.text = "Amount in Inventory: " + GameManager.instance.materialInventory[2].inventoryAmount.ToString() + "/ 3";
                    PotentialProfit1Star.text = "Potential Profit (1 Star): " + "$30";
                    PotentialProfit5Stars.text = "Potential Profit (5 Stars): " + "$150";
                    Cost.text = "Total Cost: $" + (GameManager.instance.materialInventory[2].materialCost * 3).ToString();
                }
            }
        }
        else
        {
            // Activates the Material Selector Menu
            CanvasList[4].SetActive(false);
        }
        
    }

    public void Gamestart()
    {
        // Set the projecttype
        GameManager.instance.projectType = selectedProject;

        // Check what material is selected and the blueprint, throw an error if the player does not have enough materials to craft...
        if (selectedProject == InventoryItem.ProjectType.Plank)
        {
            if (Mat1Selected && GameManager.instance.materialInventory[0].inventoryAmount >= 1)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (Mat2Selected && GameManager.instance.materialInventory[1].inventoryAmount >= 1)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (Mat3Selected && GameManager.instance.materialInventory[2].inventoryAmount >= 1)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                ErrorText.text = "Not enough materials to build item!";
            }
        }

        if (selectedProject == InventoryItem.ProjectType.Sign)
        {
            if (Mat1Selected && GameManager.instance.materialInventory[0].inventoryAmount >= 2)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (Mat2Selected && GameManager.instance.materialInventory[1].inventoryAmount >= 2)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (Mat3Selected && GameManager.instance.materialInventory[2].inventoryAmount >= 2)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                ErrorText.text = "Not enough materials to build item!";
            }
        }

        if (selectedProject == InventoryItem.ProjectType.Table)
        {
            if (Mat1Selected && GameManager.instance.materialInventory[0].inventoryAmount >= 3)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (Mat2Selected && GameManager.instance.materialInventory[1].inventoryAmount >= 3)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (Mat3Selected && GameManager.instance.materialInventory[2].inventoryAmount >= 3)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                ErrorText.text = "Not enough materials to build item!";
            }
        }
    }

    // Button functions related to starting the game
    public void StartWindow()
    {
        CanvasList[2].SetActive(true);

        if (GameManager.instance.firstTime)
        {
            if (tutorial.DialogueIndex == 12)
            {
                tutorial.IndexClick();
            }
        }
    }
 
    public void ExitStartWindow()
    {
        CanvasList[2].SetActive(false);
    }

    // Relates to buttons in the material menu
    // Select and Set Blueprint
    public void SelectPlank()
    {
        selectedProject = InventoryItem.ProjectType.Plank;
        SelectMatwindow();
    }

    public void SelectSign()
    {
        selectedProject = InventoryItem.ProjectType.Sign;
        SelectMatwindow();
    }

    public void SelectTable()
    {
        selectedProject = InventoryItem.ProjectType.Table;
        SelectMatwindow();
    }

    public void SelectMatwindow()
    {
        CanvasList[3].SetActive(true);

        if (GameManager.instance.firstTime)
        {
            if (tutorial.DialogueIndex == 13)
            {
                tutorial.IndexClick();
            }
        }
    }

    public void ExitSelectMat()
    {
        CanvasList[3].SetActive(false);
    }

    public void SelectMat1()
    {
        Mat1Selected = true;

        // Resets Error text if used before.
        ErrorText.text = "";

        // Turn on the start button
        CanvasList[5].SetActive(true);

        if (GameManager.instance.firstTime)
        {
            if (tutorial.DialogueIndex == 14)
            {
                tutorial.IndexClick();
            }
        }
    }

    public void SelectMat2()
    {
        Mat2Selected = true;

        // Resets Error text if used before.
        ErrorText.text = "";

        // Turn on the start button
        CanvasList[5].SetActive(true);
    }

    public void SelectMat3()
    {
        Mat3Selected = true;

        // Resets Error text if used before.
        ErrorText.text = "";

        // Turn on the start button
        CanvasList[5].SetActive(true);
    }

    public void ExitDescription()
    {
        Mat1Selected = false;
        Mat2Selected = false;
        Mat3Selected = false;

        // Turn off the start button
        CanvasList[5].SetActive(false);
    }

    // Relates to buttons in ShopUI
    public void ShopSelector()
    {
        CanvasList[1].SetActive(true);
        CanvasList[0].SetActive(false);
        CanvasList[2].SetActive(false);

        if (GameManager.instance.firstTime)
        {
            if (tutorial.DialogueIndex == 3)
            {
                tutorial.IndexClick();
                tutorial.canClick = true;
            }
        }
    }

    public void ExitShopSelector()
    {
        CanvasList[0].SetActive(true);
        CanvasList[1].SetActive(false);
        CanvasList[2].SetActive(false);

        if (GameManager.instance.firstTime)
        {
            if (tutorial.DialogueIndex == 11)
            {
                tutorial.IndexClick();
                tutorial.canClick = true;
            }
        }
    }
}
