using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    Vector3 magnetPos = new Vector3(0, 0, 0);
    float magnetStrength = 10000;
    Vector3 center;
    Rigidbody rb;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = GetComponent<MeshFilter>().mesh.bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        center = transform.TransformPoint(offset);
        rb.AddForce((magnetPos - center) * Time.deltaTime * magnetStrength);
        //rb.AddForce(-rb.velocity * Time.deltaTime);
    }
}
