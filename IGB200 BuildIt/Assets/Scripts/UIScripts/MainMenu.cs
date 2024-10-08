using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool OptionsIsActive;
    public GameObject SettingsPanel;
    public GameObject namePanel;
    public GameObject buttons;
    public TextMeshProUGUI nameInput;
    public TextMeshProUGUI error;

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
        // Check if the player name has been entered
        if (GameManager.instance.firstTime == true)
        {
            namePanel.SetActive(true);
            buttons.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Workshop");
        }
    }

    public void NameSubmit()
    {
        // Checks that the textfield is not empty, for some reason null is considered 1 by the text input field.
        if (nameInput.text.Length > 1)
        {
            GameManager.instance.playerName = nameInput.text;
            GameManager.instance.firstTime = false;
            SceneManager.LoadScene("Workshop");
            error.text = "";
        }
        else
        {
            error.text = "Name cannot be empty!";
        }
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
