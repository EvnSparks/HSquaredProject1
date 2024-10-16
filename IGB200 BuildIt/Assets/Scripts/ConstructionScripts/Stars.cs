using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    private float count;
    private float max = 40;
    public void Spawn()
    {
        gameObject.transform.localScale = Vector3.one * 3; 
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,60));
        count = max;
        gameObject.SetActive(true);
        
    }

    private void FixedUpdate()
    {
        if (count > -1)
        {
            gameObject.transform.localScale = Vector3.one * (2 * count / max + 1);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30 * (count / max)));
            count--;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
