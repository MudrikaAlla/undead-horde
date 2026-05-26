using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKill : MonoBehaviour
{
    Animator anim;
    AudioSource slash;
    private float attackSoundCooldown;
    private float cooldownTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        slash = GetComponent<AudioSource>();

        // Use the slash clip length as cooldown so sound replays each animation loop
        attackSoundCooldown = slash.clip != null ? slash.clip.length : 0.5f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            anim.SetBool("Kill", true);

            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                slash.Play();
                cooldownTimer = attackSoundCooldown;
            }
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            anim.SetBool("Kill", false);
            cooldownTimer = 0f; // Reset so next press plays immediately
        }
    }
}
