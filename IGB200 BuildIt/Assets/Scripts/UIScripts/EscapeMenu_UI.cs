using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu_UI : MonoBehaviour
{
    public GameObject[] escapeMenuList;

    private bool escapeMenuActive = false;
    private bool settingsActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escapeMenuActive == false)
        {
            escapeMenuList[0].SetActive(true);
            escapeMenuActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escapeMenuActive == true && settingsActive == false)
        {
            escapeMenuList[0].SetActive(false);
            escapeMenuActive = false;
        }
    }

    public void Resume()
    {
        escapeMenuList[0].SetActive(false);
        escapeMenuActive = false;
    }

    public void SettingsMenu()
    {
        escapeMenuList[1].SetActive(true);
        settingsActive = true;
    }

    public void ExitSettings()
    {
        escapeMenuList[1].SetActive(false);
        settingsActive = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
