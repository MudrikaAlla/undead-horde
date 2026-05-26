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

    private bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.gameObject.CompareTag("Sword"))
        {
            isDead = true;

            if (growl != null && growl.clip != null)
            {
                growl.Play();
            }
            else
            {
                Debug.LogWarning($"[ZombieDeath] {gameObject.name}: AudioSource or clip is missing!");
            }

            anim.SetTrigger("Dead");

            // Disable collider so zombie can't be hit again
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
        }
    }
}
