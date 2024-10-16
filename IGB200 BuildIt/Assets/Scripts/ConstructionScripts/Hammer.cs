using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject projectContainer;
    private GameObject? firstObject = null;
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
                    if (hitInfo.collider.gameObject.GetComponent<Projects>())
                    {
                        //move to mouse cursor position (if cursor is on any object
                        transform.position = hitInfo.point;
                        Debug.Log(hitInfo.normal.ToString());
                        transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

                        if (firstObject == null) firstObject = hitInfo.collider.gameObject;
                        else if (firstObject == hitInfo.collider.gameObject) firstObject = null;
                        else
                        {
                            Debug.Log("success");
                            List<MeshFilter> meshes = new List<MeshFilter>();
                            meshes.Add(firstObject.GetComponent<MeshFilter>());
                            meshes.Add(hitInfo.collider.gameObject.GetComponent<MeshFilter>());
                            CombineMesh(meshes);
                            firstObject = null;
                            // add joining particle effects and sfx here
                        }
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0) && firstObject == null) transform.position = Vector3.forward * 100;
        }
        else transform.position = Vector3.forward * 100;
    }

    public void CombineMesh(List<MeshFilter> sourceMeshFilters)
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

