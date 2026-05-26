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

    private bool hasWon = false;

    [SerializeField] private float quitDelay = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (hasWon) return;

        if (other.gameObject.CompareTag("Maria"))
        {
            hasWon = true;
            win.Play();
            StartCoroutine(WaitAndQuit());
        }
    }

    IEnumerator WaitAndQuit()
    {
        yield return new WaitForSeconds(quitDelay);
        Application.Quit();
    }
}
