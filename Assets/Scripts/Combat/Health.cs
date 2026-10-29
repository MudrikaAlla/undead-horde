using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private CharacterStats stats;

    private float currentHealth;

    // Events that other systems can subscribe to
    public event Action<float, float> OnHealthChanged;  // (current, max)
    public event Action OnDeath;

    public bool IsDead { get; private set; }
    public float CurrentHealth => currentHealth;
    public float MaxHealth => stats.maxHealth;

    void Start()
    {
        currentHealth = stats.maxHealth;
        OnHealthChanged?.Invoke(currentHealth, stats.maxHealth);
    }

    public void TakeDamage(float amount)
    {
        if (IsDead) return;

        currentHealth = Mathf.Max(currentHealth - amount, 0f);
        OnHealthChanged?.Invoke(currentHealth, stats.maxHealth);

        if (currentHealth <= 0f)
        {
            IsDead = true;
            OnDeath?.Invoke();
        }
    }
}
