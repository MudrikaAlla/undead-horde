using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    //GameObject currentGameObject;
    Animator anim;
    AudioSource growl;

    void Start()
    {
        //currentGameObject = this.gameObject;
        //getting animator component attached to the zombie
        anim = GetComponent<Animator>();

        //getting the audio source from the zombie
        growl = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    //method to kill the zombie(execute dying animation) when sword touches the zombie
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            //play the audio attached to the zombie
            growl.Play();
            Debug.Log("Sword Touched");
            anim.SetTrigger("Dead");
        }
    }
}
