using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    Animator anim;
    AudioSource growl;
    KillCounter killCounter;
    Health health;

    void Start()
    {
        anim = GetComponent<Animator>();
        growl = GetComponent<AudioSource>();
        killCounter = FindObjectOfType<KillCounter>();
        health = GetComponent<Health>();

        // Subscribe to the Health component's death event
        health.OnDeath += HandleDeath;
    }

    void OnDestroy()
    {
        // Always unsubscribe to prevent memory leaks
        if (health != null) health.OnDeath -= HandleDeath;
    }

    void HandleDeath()
    {
        if (growl != null && growl.clip != null)
            growl.Play();

        anim.SetTrigger("Dead");

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        if (killCounter != null) killCounter.RegisterKill();
        if (CinemachineShake.Instance != null) CinemachineShake.Instance.Shake();
    }
}
