using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewMaterial : MonoBehaviour, IPointerEnterHandler
{
    public GameObject rubbishButton;
    public DragProjects grabObject;
    public GameObject newProject;
    public GameObject[] blueprints;
    public PlaneSlice planeSlice;
    public void CreateNewProject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            grabObject.grabbedProject = Instantiate(newProject, hitInfo.point, Quaternion.Euler(0, 0, 0)).GetComponent<Projects>();
            GameManager.instance.SetState(GameManager.State.NewProject);
        }
            
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.hovered.Contains(rubbishButton))
        {
            planeSlice.RemoveObjectFromList(grabObject.grabbedProject.gameObject);
            Destroy(grabObject.grabbedProject.gameObject);
        }
    }

    public void SaveProject()
    {
        float rating = 0;
        int enabledCount = 0;
        foreach (GameObject blueprint in blueprints)
        {
            if (blueprint.GetComponent<MeshRenderer>().enabled)
            {
                rating += blueprint.GetComponent<DetectOverlap>().Overlap();
                enabledCount++;
            }
        }
        rating = rating / enabledCount;
        Debug.Log(rating);
        GameManager.instance.inventory.Add(new InventoryItem(rating, 0, GameManager.instance.projectType));
    }
}
