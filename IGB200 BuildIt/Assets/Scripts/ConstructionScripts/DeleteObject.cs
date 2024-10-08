using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    float lifeTime = 0.5f;
    float shrinkRate = 0.4f;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > lifeTime)
        {
            transform.localScale -= Vector3.one * shrinkRate * Time.deltaTime * (Time.time - startTime);
            if (transform.localScale.x < 0.05f || transform.localScale.y < 0.05f || transform.localScale.z < 0.05f)
                Destroy(this.gameObject);
        }
    }
}
