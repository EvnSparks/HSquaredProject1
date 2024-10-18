using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        // Checks if the input for player name is not null or is just empty spaces
        if (!string.IsNullOrWhiteSpace(nameInput.text))
        {
            GameManager.instance.playerName = nameInput.text;
            SceneManager.LoadScene("Tutorial");
            error.text = "";
        }
        else
        {
            error.text = "Name cannot be empty or have spaces!";
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
