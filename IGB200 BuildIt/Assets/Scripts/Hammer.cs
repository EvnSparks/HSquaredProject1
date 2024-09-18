using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject projectContainer;
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

                    Ray nailRay = new Ray(transform.position, -hitInfo.normal);
                    RaycastHit[] nailHit = Physics.RaycastAll(nailRay, 2f);

                    Debug.DrawRay(transform.position, -hitInfo.normal, Color.red, 1f, false);

                    Debug.Log(nailHit.Length);

                    List<MeshFilter> hits = new List<MeshFilter>();
                    MeshFilter currentMesh;
                    foreach (RaycastHit hit in nailHit)
                    {
                        if (hit.collider.gameObject.GetComponent<MeshFilter>())
                        {
                            currentMesh = hit.collider.gameObject.GetComponent<MeshFilter>();
                            if (!hits.Contains(currentMesh)) hits.Add(currentMesh);
                        }
                    }   
                    if (hits.Count > 1)
                    {
                        Debug.Log("success");
                        CombineMeshes(hits);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0)) transform.position = Vector3.forward * 100;
        }
        else transform.position = Vector3.forward * 100;
    }

    public void CombineMeshes(List<MeshFilter> sourceMeshFilters)
    {
        var combine = new CombineInstance[sourceMeshFilters.Count];

        for (int i = 0; i < sourceMeshFilters.Count; i++)
        {
            combine[i].mesh = sourceMeshFilters[i].mesh;
            combine[i].transform = sourceMeshFilters[i].transform.localToWorldMatrix;
        }
        Mesh mesh = new Mesh();
        mesh.CombineMeshes(combine);
        sourceMeshFilters[0].mesh = mesh;
        for (int i = 1; i < sourceMeshFilters.Count; i++)
            Destroy(sourceMeshFilters[i].gameObject);
    }
}

