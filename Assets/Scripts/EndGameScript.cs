using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    AudioSource win;
    void Start()
    {
        //getting the audio source from the treasure chest
        win = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    //game exit is triggered when player goes near the treasure chest
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Maria"))
        {
            //plays the audio attached to the treasure chest
            win.Play();
            //Debug.Log("WIN!");
            StartCoroutine(DelayLittle());
        }
    }

    //method to delay exiting the game by five seconds
    IEnumerator DelayLittle()
    {
        //https://forum.unity.com/threads/c-how-to-close-the-game-after-x-seconds.525693/
        yield return new WaitForSeconds(5); //wait 5 secconds
        Debug.Log("Yay");
        Application.Quit();
    }
}
