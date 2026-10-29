using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private CharacterStats ownerStats;

    public void SetStats(CharacterStats stats)
    {
        ownerStats = stats;
    }

    private void OnTriggerEnter(Collider other)
    {

        IDamageable target = other.GetComponentInParent<IDamageable>();

        if (target == null) return;

        if (target.IsDead) return;

        IDamageable self = GetComponentInParent<IDamageable>();
        if (target == self) return;

        target.TakeDamage(ownerStats.attackDamage);
    }
}
