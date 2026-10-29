using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Health health;
    Animator anim;

    [SerializeField] private GameObject gameOverCanvas;

    void Start()
    {
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();

        health.OnDeath += HandleDeath;

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);
    }

    void OnDestroy()
    {
        if (health != null) health.OnDeath -= HandleDeath;
    }

    void HandleDeath()
    {
        anim.SetTrigger("Dead");

        // Disable player controls
        var controller = GetComponent<ThirdPersonController>();
        if (controller != null) controller.enabled = false;

        var combat = GetComponent<ClickToKill>();
        if (combat != null) combat.enabled = false;

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(true);
    }
}
