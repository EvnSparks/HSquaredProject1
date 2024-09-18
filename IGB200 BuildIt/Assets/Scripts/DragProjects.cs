using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DragProjects : MonoBehaviour
{
    public Projects? grabbedProject = null;
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
                    try
                    {
                        grabbedProject = hitInfo1.collider.gameObject.GetComponent<Projects>();
                        offset = hitInfo1.point - grabbedProject.magnetPos;
                        Debug.Log(grabbedProject);
                    }
                    catch { }
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
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            grabbedProject = null;
            GameManager.instance.SetState(GameManager.State.Default);
        }
    }
}
