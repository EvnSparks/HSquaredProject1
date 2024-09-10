using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public Transform anchor;

    public float turnSpeed = 10;

    public float heightSpeed = 3;
    public float maxHeight = 10;

    public float zoomSpeed = 1;
    public float maxZoom = 60;
    public float minZoom = 10;
    

    private float angle = 0;
    private float cameraHeight = 0.5f;
    private float cameraZoom;

    private Camera camera;

    private void Start()
    {
        camera = this.GetComponent<Camera>();
        cameraZoom = maxZoom;
    }

    // Update is called once per frame
    void Update()
    {
        // handle inputs
        if (Input.GetKey(KeyCode.A))
        {
            angle += turnSpeed * Time.deltaTime;
            if (angle > 360) angle -= 360;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle -= turnSpeed * Time.deltaTime;
            if (angle < 0) angle += 360;
        }
        if (Input.GetKey(KeyCode.W))
        {
            cameraHeight += heightSpeed * Time.deltaTime;
            if (cameraHeight > maxHeight) cameraHeight = maxHeight;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraHeight -= heightSpeed * Time.deltaTime;
            if (cameraHeight < 0) cameraHeight = 0;
        }
        if (Input.mouseScrollDelta.y != 0)
        {
            cameraZoom += Input.mouseScrollDelta.y * zoomSpeed;
            if (cameraZoom > maxZoom) cameraZoom = maxZoom;
            if (cameraZoom < minZoom) cameraZoom = minZoom;
        }

        // Adjust Camera settings accordingly
        camera.fieldOfView = cameraZoom;
        anchor.position = new Vector3(anchor.transform.position.x, cameraHeight, anchor.transform.position.z);
        anchor.rotation = Quaternion.Euler(0, angle, 0);
    }
}
