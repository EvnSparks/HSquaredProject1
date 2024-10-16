using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Finish_UI : MonoBehaviour
{
    private bool escapeMenuActive = false;
    private InventoryItem item;
    
    //Display settings
    [SerializeField]
    private float[] waitTime = new float[3];
    [SerializeField]
    private TMP_Text tmp;
    [SerializeField]
    private Stars[] accStars = new Stars[5];
    [SerializeField]
    private Stars[] speedStars = new Stars[5];
    private string originalText;

    private void Awake()
    {
        originalText = tmp.text; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escapeMenuActive == true)
        {
            this.gameObject.SetActive(false);
            escapeMenuActive = false;
        }
    }

    public void Resume()
    {
        tmp.text = originalText;
        foreach (Stars star in accStars) star.Hide();
        foreach (Stars star in speedStars) star.Hide();
        this.gameObject.SetActive(false);
        escapeMenuActive = false;
        
    }

    public void MainMenu()
    {
        GameManager.instance.inventory.Add(item);
        SceneManager.LoadScene("WorkShop");
    }

    
    public void ShowMenu(InventoryItem item)
    {
        this.gameObject.SetActive(true);
        escapeMenuActive = true;
        this.item = item;
        
        // display results
        StartCoroutine(ShowResults());
    }
    private IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(waitTime[0]);
        for (int i = 0; i < Mathf.Round(item.accuracyRating); i++)
        {
            accStars[i].Spawn();
            //add SFX here
            yield return new WaitForSeconds(waitTime[1]);
        }
        yield return new WaitForSeconds(waitTime[0]);
        Debug.Log(Mathf.Round(item.speedRating));
        for (int i = 0; i < Mathf.Round(item.speedRating); i++)
        {
            speedStars[i].Spawn();
            // add SFX here
            yield return new WaitForSeconds(waitTime[1]);
        }
        yield return new WaitForSeconds(waitTime[0]);
        float cost = 0;
        for (int i = 0; i < item.materialCost * item.materialQuality * 5; i++)
        {
            cost++;
            tmp.text = originalText + cost.ToString();
            yield return new WaitForSeconds(waitTime[2]);
        }
    }
}
