using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SawMovement : MonoBehaviour
{
    public AudioClip sawSound;
    public AudioSource soundPlayer;
    public float soundDuration = 10;
    public GameObject slicer;
    public float baseSpeed = 50f;
    public float cutSpeed = 5f;
    public float sawAnimationSpeed = 1f;
    public float sawAnimationStrength = 1f;
    public float sawAnimationTurnStrength = 0.1f;
    public int cutting = 0;
    float speedMultiplier;
    PlaneSlice planeSlice;
    public List<MeshRenderer> meshRenderer;
    public Transform sawMotion;

    private float soundStartTime;

    void Start()
    {
        if (slicer != null)
        {
            planeSlice = slicer.GetComponent<PlaneSlice>();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        bool inObject = planeSlice.InsideObject();
        if (cutting == 0 && Input.GetKey(KeyCode.Mouse0) && !inObject && GameManager.instance.GetState() == GameManager.State.UsingSaw)
        {
            cutting = 1;
            planeSlice.IsEnabled(true);
            foreach (MeshRenderer renderer in meshRenderer)
                renderer.enabled = true;
        }
        if (cutting == 1 && !Input.GetKey(KeyCode.Mouse0) && !inObject)
        {
            cutting = 0;
            planeSlice.IsEnabled(false);
            foreach (MeshRenderer renderer in meshRenderer)
                renderer.enabled = false;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, LayerMask.GetMask("Default")))
        {
            //move to mouse cursor position (if cursor is on any object
            if (cutting == 1 && inObject)
            {
                transform.position += (hitInfo.point - transform.position) * cutSpeed * Time.fixedDeltaTime;
                //add sawing motion
                sawMotion.transform.position += (transform.position - Camera.main.transform.position).normalized * sawAnimationStrength * Mathf.Sin(Time.time * sawAnimationSpeed) * Time.fixedDeltaTime;
                Vector3 lookPos = hitInfo.point - sawMotion.transform.position;
                Quaternion rotation = Quaternion.LookRotation(-lookPos, transform.forward);
                sawMotion.transform.localRotation = Quaternion.Euler(0, 180, Mathf.RoundToInt(rotation.eulerAngles.z / 45) * 45);
                if (Time.time > soundStartTime + soundDuration)
                {
                    soundPlayer.Stop();
                    soundPlayer.PlayOneShot(sawSound);
                    soundStartTime = Time.time;
                }
            }
            else
                soundPlayer.Stop();
                transform.position += (hitInfo.point - transform.position) * baseSpeed * Time.fixedDeltaTime;
        }
    }
}
