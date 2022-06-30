using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] protected float currentHealth;
    
    public float Health
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value >= 0f ? value : 0f;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
        set
        {
            maxHealth = value >= 0f ? value : 0f;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
    public virtual void Heal(float healing)
    {
        Health += healing;
    }
    public bool DeadCheck { get; protected set; }
    public virtual void Damage(float power)
    {
        currentHealth -= power;
        if (currentHealth <= 0f && !DeadCheck)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        DeadCheck = true;

    }
    
}
