using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public GameObject slicer;
    public float baseSpeed = 50f;
    public float cutSpeed = 5f;
    public float sawAnimationSpeed = 1f;
    public float sawAnimationStrength = 1f;
    public int cutting = 0;
    float speedMultiplier;
    PlaneSlice planeSlice;
    public List<MeshRenderer> meshRenderer;
    public Transform sawMotion;

    void Start()
    {
        if (slicer != null)
        {
            planeSlice = slicer.GetComponent<PlaneSlice>();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        bool inObject = planeSlice.InsideObject();
        if (cutting == 0 && Input.GetKey(KeyCode.Mouse0) && !inObject && GameManager.instance.GetState() == GameManager.State.UsingSaw)
        {
            cutting = 1;
            planeSlice.IsEnabled(true);
            foreach (MeshRenderer renderer in meshRenderer)
                renderer.enabled = true;
        }
        if (cutting == 1 && !Input.GetKey(KeyCode.Mouse0) && !inObject)
        {
            cutting = 0;
            planeSlice.IsEnabled(false);
            foreach (MeshRenderer renderer in meshRenderer)
                renderer.enabled = true;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, LayerMask.GetMask("Default")))
        {
            //move to mouse cursor position (if cursor is on any object
            if (cutting == 1 && inObject)
            {
                transform.position += (hitInfo.point - transform.position) * cutSpeed * Time.fixedDeltaTime;
                //add sawing motion
                sawMotion.transform.position += (transform.position - Camera.main.transform.position).normalized * sawAnimationStrength * Mathf.Sin(Time.time * sawAnimationSpeed) * Time.fixedDeltaTime;
            }   
            else 
                transform.position += (hitInfo.point - transform.position) * baseSpeed * Time.fixedDeltaTime;
        }
    }
}
