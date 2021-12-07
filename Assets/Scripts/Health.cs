using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;


    public Action<Health> OnTakeDamage { get; set; }
    public Action<Health> OnDeath { get; set; }

    public bool IsDead => health <= 0;
    public int CurrentHealth => health;
    public int MaxHealth => maxHealth;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
        }

        if (IsDead)
        {
            OnDeath?.Invoke(this);
        }
        else
        {
            OnTakeDamage?.Invoke(this);
        }
    }
}