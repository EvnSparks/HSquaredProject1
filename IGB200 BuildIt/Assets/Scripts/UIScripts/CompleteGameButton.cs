using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGameButton : MonoBehaviour
{
    public GameObject[] CompleteUI;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.quest3complete == true)
        {
            CompleteUI[0].SetActive(true);
        }    
    }

    public void FinishMenu()
    {
        CompleteUI[1].SetActive(true);
        CompleteUI[2].SetActive(true);
        CompleteUI[3].SetActive(true);
    }

    public void Continue ()
    {
        CompleteUI[1].SetActive(false);
        CompleteUI[2].SetActive(false);
        CompleteUI[3].SetActive(false);
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
