using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOverlap : MonoBehaviour
{
    public InventoryItem.ProjectType projectType;
    private Vector3[] dir = new Vector3[6];
    private float scoreMult = 5.5f;

    private void Start()
    {
        dir[0] = new Vector3(1, 0, 0);
        dir[1] = new Vector3(-1, 0, 0);
        dir[2] = new Vector3(0, 1, 0);
        dir[3] = new Vector3(0, -1, 0);
        dir[4] = new Vector3(0, 0, 1);
        dir[5] = new Vector3(0, 0, -1);

        if (GameManager.instance.projectType == projectType) GetComponent<MeshRenderer>().enabled = true;
        else GetComponent<MeshRenderer>().enabled = false;
    }

    public float Overlap() // returns a rating from 0 to 5 stars
    {
        float score = 0;
        float target = 0;
        foreach (Vector3 d in dir)
        {
            target = MathF.Sqrt(MathF.Pow(d.x * transform.localScale.x, 2) + MathF.Pow(d.y * transform.localScale.y, 2) + MathF.Pow(d.z * transform.localScale.z, 2));
            Debug.DrawRay(transform.position + d * (1 + target / 2), -d * (1 + target), Color.black, 3);
            if (Physics.Raycast(transform.position + d * (1 + target / 2), -d, out RaycastHit hitInfo, 1 + target / 2, LayerMask.GetMask("Default")))
            {
                Debug.Log("actual dist " + hitInfo.distance);
                score += scoreMult * (1 - MathF.Sqrt(Mathf.Abs(1 - hitInfo.distance)));
            }
            else Debug.Log("failed to hit an object on Default Layer within 5 in direction" + d.ToString());
            Debug.Log("score" + score);
        }
        return score / dir.Length;
    }
}
