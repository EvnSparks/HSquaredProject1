using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragProjects : MonoBehaviour
{
    public Projects? grabbedProject = null;
    public GameObject plane;
    private Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray1, out RaycastHit hitInfo1, 100, LayerMask.GetMask("Default")))
            {
                if (hitInfo1.collider != null)
                {
                    if (hitInfo1.collider.gameObject.GetComponent<Projects>())
                    {
                        grabbedProject = hitInfo1.collider.gameObject.GetComponent<Projects>();
                        offset = hitInfo1.point - grabbedProject.magnetPos;
                        plane.transform.position = hitInfo1.point;
                    }
                }
            }
        }
        if (grabbedProject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, LayerMask.GetMask("ObstructsSaw")))
            {
                grabbedProject.magnetPos = hitInfo.point - offset;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0) && GameManager.instance.state == GameManager.State.NewProject)
        {
            grabbedProject = null;
            GameManager.instance.SetState(GameManager.State.Default);
        }
    }
}
