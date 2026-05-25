using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAndQuit : MonoBehaviour
{
    //method to play the game, changes to Maria scene when called
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //method to quit the application
    public void QuitGame()
    {
        //Debug.Log("Quit Game");
        Application.Quit();
    }
}
