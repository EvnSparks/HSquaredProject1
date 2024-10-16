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
            Destroy(grabObject.grabbedProject.gameObject);
        }
    }

    public void SaveProject()
    {

    }
}
