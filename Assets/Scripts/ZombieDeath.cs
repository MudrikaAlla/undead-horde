using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    Animator anim;
    AudioSource growl;
    private KillCounter killCounter;

    void Start()
    {
        //currentGameObject = this.gameObject;
        anim = GetComponent<Animator>();
        growl = GetComponent<AudioSource>();
        killCounter = FindObjectOfType<KillCounter>();
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

            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;

            if (killCounter != null) killCounter.RegisterKill();
        }
    }
}
