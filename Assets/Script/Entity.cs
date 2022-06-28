using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] protected float health;

    public virtual float Health
    {
        get { return health; }
        set
        {
            health = value >= 0f ? value : 0f;
            if (health > maxHealth)
                health = maxHealth;
        }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
        set
        {
            maxHealth = value >= 0f ? value : 0f;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
    public bool DeadCheck { get; protected set; }

    public virtual void OnEnable()
    {
        DeadCheck = false;
        Health = MaxHealth;
    }

    public virtual void Heal(float healing)
    {
        Health += healing;
    }
    public virtual void Damage(float power)
    {
        health -= power;
        if(health <= 0f&&!DeadCheck)
        {
            DeadCheck = true;
        }
    }
    
}
