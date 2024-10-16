using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projects : MonoBehaviour
{
    public Vector3 magnetPos = new Vector3(0, 0, 0);
    public Vector3 magnetRotation = new Vector3(0, 0, 0);
    public float tableOffset = 0;
    Vector3 center;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            GameManager.instance.currentProject = this;
        }
        catch { }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(magnetPos);
        rb.MoveRotation(Quaternion.Euler(magnetRotation));
    }
}
