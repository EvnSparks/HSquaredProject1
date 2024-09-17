using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetState() == GameManager.State.UsingHammer)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    //move to mouse cursor position (if cursor is on any object
                    transform.position = hitInfo.point;
                    Debug.Log(hitInfo.normal.ToString());
                    transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                    RaycastHit[] hitInfo2 = Physics.RaycastAll(hitInfo.point, hitInfo.normal);
                    List<Collider> hits = new List<Collider>();
                    foreach (RaycastHit hit in hitInfo2)
                        if (!hits.Contains(hit.collider)) hits.Add(hit.collider);
                    if (hits.Count > 1)
                    {
                        List<Vector3> newMagnetPos = new List<Vector3>();
                        foreach (Collider proj in hits) newMagnetPos.Add(proj.GetComponentInParent<Projects>().magnetPos);

                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0)) transform.position = Vector3.forward * 100;
        }
        else transform.position = Vector3.forward * 100;
    }
}

