using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterStats", menuName = "Undead Horde/Character Stats")]
public class CharacterStats : ScriptableObject
{
    [Header("Health")]
    public float maxHealth = 100f;

    [Header("Combat")]
    public float attackDamage = 25f;
    public float attackCooldown = 0.5f;

    [Header("Movement")]
    public float moveSpeed = 5f;
}
