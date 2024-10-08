using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSlice : MonoBehaviour
{
    public float cutForce = 10f;
    public float snappingPoints = 1.0f; // recommended to keep as whole numbers
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

                // normalise vectors to prevent rounding to (0, 0, 0)
                side1.Normalize();
                side2.Normalize();

                // increase scale to number of snapping points
                side1 = side1 * snappingPoints;
                side2 = side2 * snappingPoints;

                // round to make neater edges
                side1 = Vector3Int.RoundToInt(side1);
                side2 = Vector3Int.RoundToInt(side2);

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
                // save the original object's position
                Vector3 tempPos = other.gameObject.GetComponent<Projects>().magnetPos;
                // remove the original object
                startSlice.Remove(other.gameObject);
                Destroy(other.gameObject);

                Rigidbody rigidbody = slices[1].GetComponent<Rigidbody>();
                Vector3 newNormal = transformedNormal + Vector3.up * cutForce;
                rigidbody.AddForce(newNormal, ForceMode.Impulse);

                // delete the smaller object
                int deleteObject = FindSmallestMeshNum(slices);
                slices[deleteObject].AddComponent<DeleteObject>();
                slices[deleteObject].GetComponent<Rigidbody>().useGravity = true;
                Destroy(slices[deleteObject].GetComponent<Sliceable>());

                // apply magnetism to larger object
                Projects project = slices[-1 * (deleteObject - 1)].AddComponent<Projects>();
                project.magnetPos = tempPos;
                project.gameObject.GetComponent<Rigidbody>().isKinematic = true;
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

    public void RemoveObjectFromList(GameObject go)
    {
        insideObject.Remove(go);
    }
}
