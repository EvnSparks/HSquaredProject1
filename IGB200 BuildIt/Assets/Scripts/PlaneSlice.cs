using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneSlice : MonoBehaviour
{
    public float cutForce = 10f;
    bool isEnabled = false;
    public Dictionary<GameObject, Vector3> startSlice = new Dictionary<GameObject, Vector3>();
    public List<GameObject> insideObject = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Sliceable>())
        {
            insideObject.Add(other.gameObject);
            if (isEnabled) 
                startSlice.Add(other.gameObject, other.ClosestPoint(transform.position));
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Sliceable>())
        {
            insideObject.Remove(other.gameObject);
            if (isEnabled && startSlice.ContainsKey(other.gameObject))
            {
                Vector3 endSlice = other.ClosestPoint(transform.position);
                //Create a triangle between the start, end and camera so that we can get the normal
                Vector3 side1 = endSlice - startSlice[other.gameObject];
                Vector3 side2 = endSlice - Camera.main.gameObject.transform.position;

                //Get the point perpendicular to the triangle above which is the normal
                //https://docs.unity3d.com/Manual/ComputingNormalPerpendicularVector.html
                Vector3 normal = Vector3.Cross(side1, side2).normalized;

                //Transform the normal so that it is aligned with the object we are slicing's transform.
                Vector3 transformedNormal = ((Vector3)(other.gameObject.transform.localToWorldMatrix.transpose * normal)).normalized;

                //Get the enter position relative to the object we're cutting's local transform
                Vector3 transformedStartingPoint = other.gameObject.transform.InverseTransformPoint(startSlice[other.gameObject]);

                Plane plane = new Plane();
                plane.SetNormalAndPosition(transformedNormal, transformedStartingPoint);

                //Flip the plane so that we always know which side the positive mesh is on
                if (Vector3.Dot(Vector3.up, transformedNormal) < 0)
                {
                    plane = plane.flipped;
                }

                GameObject[] slices = Slicer.Slice(plane, other.gameObject);
                // remove the original object
                startSlice.Remove(other.gameObject);
                Destroy(other.gameObject);

                Rigidbody rigidbody = slices[1].GetComponent<Rigidbody>();
                Vector3 newNormal = transformedNormal + Vector3.up * cutForce;
                rigidbody.AddForce(newNormal, ForceMode.Impulse);

                // delete the smaller object
                int deleteObject = FindSmallestMeshNum(slices);
                slices[deleteObject].AddComponent<DeleteObject>();
                Destroy(slices[deleteObject].GetComponent<Sliceable>());

                // apply magnetism to larger object
                slices[-1 * (deleteObject - 1)].AddComponent<Magnetism>();
            }
        }
    }

    private int FindSmallestMeshNum(GameObject[] objects)
    {
        float smallestMeshSize = -1f;
        int smallestMesh = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 v3MeshSize = objects[i].GetComponent<MeshCollider>().sharedMesh.bounds.size;
            float meshSize = v3MeshSize.x * v3MeshSize.y * v3MeshSize.z;
            if (smallestMeshSize == -1 || meshSize < smallestMeshSize)
            {
                smallestMesh = i;
                smallestMeshSize = meshSize;
            }
        }
        return smallestMesh;
    }

    public void IsEnabled(bool enabled)
    {
        if (!enabled) startSlice.Clear();
        isEnabled = enabled;
    }

    public bool InsideObject()
    {
        return (insideObject.Count != 0);
    }

    public bool InsideObject(GameObject other)
    {
        return insideObject.Contains(other);
    }
}
