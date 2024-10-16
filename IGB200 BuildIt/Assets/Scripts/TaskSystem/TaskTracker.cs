using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskTracker : MonoBehaviour
{
    // Stores a list of tasks to be striked through once completed
    public List<TextMeshProUGUI> taskList;
    public int planksMade;

    // When the object is activated at any time it will check to update the text by striking them through
    void OnEnable()
    {
        // Task 1 Tracker
        if (planksMade >= 3)
        {
            taskList[0].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
        }

        // Trask 2 Tracker - To be Done

        // Task 3 Tracker - To be Done

        // Task 4 Tracker - To be Done
    }
}
