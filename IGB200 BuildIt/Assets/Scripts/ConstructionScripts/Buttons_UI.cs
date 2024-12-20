using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons_UI : MonoBehaviour, IPointerEnterHandler
{
    // Setting up variables
    public GameObject rubbishButton;
    public DragProjects grabObject;
    public GameObject newProject;
    public GameObject[] blueprints;
    public PlaneSlice planeSlice;
    public Finish_UI Finish;
    private float time;
    private int materialsUsed = 1;
    public TutorialProgress tutorialProgress;

    private void Start()
    {
        time = Time.time;
    }

    public void CreateNewProject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            grabObject.grabbedProject = Instantiate(newProject, hitInfo.point, Quaternion.Euler(0, 0, 0)).GetComponent<Projects>();
            GameManager.instance.SetState(GameManager.State.NewProject);
            materialsUsed++;
            tutorialProgress.create = true;
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.hovered.Contains(rubbishButton))
        {
            planeSlice.RemoveObjectFromList(grabObject.grabbedProject.gameObject);
            Destroy(grabObject.grabbedProject.gameObject);
            materialsUsed--;
        }
        //add resize on hover
    }

    public void SaveProject()
    {
        float rating = 0;
        Vector2 overlap;
        float leastAccurate = 6;
        int enabledCount = 0;
        foreach (GameObject blueprint in blueprints)
        {
            if (blueprint.GetComponent<MeshRenderer>().enabled)
            {
                overlap = blueprint.GetComponent<DetectOverlap>().Overlap();
                rating += overlap.x;
                if (overlap.y < leastAccurate) leastAccurate = overlap.y;
                enabledCount++;
            }
        }
        rating = ((rating / enabledCount) + leastAccurate) / 2;
        Debug.Log(rating);
        Debug.Log(5 - (Time.time - time) / 60);

        Finish.ShowMenu(new InventoryItem(rating, Time.time - time, GameManager.instance.materialInventory[(int)GameManager.instance.materialselected].materialCost, 
            GameManager.instance.materialselected, GameManager.instance.projectType));
    }
}
