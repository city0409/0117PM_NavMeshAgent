using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    public int currentHealth { get; private set; }
    [SerializeField]
    protected  Stats damage;
    [SerializeField]
    protected Stats armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    } 

    [ContextMenu("Attack")]
    private void Attack()
    {
        TakeDamage(10);
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;

        Debug.Log("Damage:" + damage);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die");

    }
}
