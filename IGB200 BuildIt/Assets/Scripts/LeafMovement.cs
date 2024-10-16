using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafMovement : MonoBehaviour
{
    //Leaf movement how drastic
    public float radiusX = 0.02f;
    public float radiusY = 0.045f;
    public float windSpeed = 1.5f;
    private Vector3 centerPos;
    void Start()
    {
        centerPos = new Vector3(1.31f,8.66f,0.06f);
    }

    // Update is called once per frame
    void Update()
    {
        float x = centerPos.x + radiusX *  Mathf.Cos(Time.time * windSpeed);
        float y = centerPos.y + radiusY *  Mathf.Cos(Time.time * windSpeed);

        transform.position = new Vector3(x,y,-1);

    }
}
