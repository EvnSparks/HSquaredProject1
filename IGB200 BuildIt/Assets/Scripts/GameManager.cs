using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    //Singleton Setup
    public static GameManager instance = null;
    public string currentScene;
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public InventoryItem currentProject;
    public InventoryItem.ProjectType projectType = InventoryItem.ProjectType.Plank;

    //Universal Shop UI Tracker
    public int activeShop;
    public bool shopItemSelected;
    public float money;

    public enum State
    {
        Default, // resets to last tool used
        UsingSaw, 
        UsingHammer,
        NewProject,
        SelectSlice
    }
    public State state = State.UsingSaw;
    private State lastTool = State.UsingSaw;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        switch (state)
        {
            case State.UsingSaw:
                break;
            case State.UsingHammer:
                break;
            case State.NewProject:
                break;
            case State.SelectSlice:
                break;
            default:
                break; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetState(State.UsingSaw);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetState(State.UsingHammer);
    }

    public void SetState(State newState)
    {
        if (state == State.UsingSaw || state == State.UsingHammer) lastTool = state;
        if (newState == State.Default) state = lastTool;
        else state = newState;
    }
    public State GetState() { return state; }

    // Awake Checks - Singleton setup
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
