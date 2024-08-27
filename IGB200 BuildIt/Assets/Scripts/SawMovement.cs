using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public GameObject slicer;
    public float baseSpeed = 50f;
    public float cutSpeed = 5f;
    public float sawAnimationSpeed = 1f;
    public float sawAnimationStrength = 1f;
    int cutting = 0;
    float speedMultiplier;
    PlaneSlice planeSlice;

    void Start()
    {
        if (slicer != null)
            planeSlice = slicer.GetComponent<PlaneSlice>();
    }


    // Update is called once per frame
    void Update()
    {
        bool inObject = planeSlice.InsideObject();
        if (cutting == 0 && Input.GetKey(KeyCode.Mouse0) && !inObject)
        {
            cutting = 1;
            planeSlice.IsEnabled(true);
        }
        if (cutting == 1 && !Input.GetKey(KeyCode.Mouse0) && !inObject)
        {
            cutting = 0;
            planeSlice.IsEnabled(false);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            //move to mouse cursor position (if cursor is on any object
            if (cutting == 1 && inObject)
            {
                transform.position += (hitInfo.point - transform.position) * cutSpeed * Time.deltaTime;
                //add sawing motion
                transform.position += (transform.position - Camera.main.transform.position).normalized * sawAnimationStrength * Mathf.Sin(Time.time * sawAnimationSpeed) * Time.deltaTime;
            }   
            else 
                transform.position += (hitInfo.point - transform.position) * baseSpeed * Time.deltaTime;
        }
            

        else
            // store object away from camera
            transform.position = Vector3.forward * 100;
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);

        
    }
}
