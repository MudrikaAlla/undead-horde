using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public bool GameIsPaused;
    public GameObject PauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // This flips a Booleon from False -> True or True -> False. Why is this?
            GameIsPaused = !GameIsPaused;
            // The ! means "not". So 'Not True' = False, and 'Not False' = True.
        }

        // Let's interpret this as just reading: The game is paused? 0. Otherwise, 1.
        Time.timeScale = GameIsPaused ? 0f : 1f;

        // If that syntax doesn't sink in right away, we can always do it the longer way::
        // NOTE: you only need to choose one way of setting Time.timeScale, either the method
        // above or the method below. Pick the one whose syntax you prefer!
        if (GameIsPaused)
        {
            Time.timeScale = 0f; // Freeze the game
        }
        else
        {
            Time.timeScale = 1f;  // Resume the game
        }

        PauseCanvas.SetActive(GameIsPaused);
    }
}
