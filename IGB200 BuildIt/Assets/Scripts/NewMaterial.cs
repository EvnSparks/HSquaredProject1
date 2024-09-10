using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewMaterial : MonoBehaviour, IPointerEnterHandler
{
    public GameObject rubbishButton;
    public DragProjects grabObject;
    public GameObject newProject;
    public void CreateNewProject()
    {
        grabObject.grabbedProject = Instantiate(newProject).GetComponent<Projects>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.hovered.Contains(rubbishButton))
        {
            Destroy(grabObject.grabbedProject.gameObject);
        }
    }
}
