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
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = !GameIsPaused;
            Time.timeScale = GameIsPaused ? 0f : 1f;
            PauseCanvas.SetActive(GameIsPaused);
        }
    }
}
