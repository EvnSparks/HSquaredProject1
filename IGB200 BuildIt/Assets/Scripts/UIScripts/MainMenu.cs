using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool OptionsIsActive;
    public GameObject SettingsPanel;

    void Start()
    {
        OptionsIsActive = false;
    }

    void Update()
    {
        if(OptionsIsActive)
        {
            SettingsPanel.SetActive(true);
        }
        else
        {
            SettingsPanel.SetActive(false);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Workshop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsToggle()
    {
        if(!OptionsIsActive)
        {
            OptionsIsActive = true;
        }
        else
        {
            OptionsIsActive = false;
        }
    }
}
