using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : EntityHealth
{
    [SerializeField] private float playerHealth = 100;
    private void Awake()
    {
        this.DeadCheck = false;
        this.Health = playerHealth;
        this.MaxHealth = playerHealth;
    }
    public override void Damage(float power)
    {
        base.Damage(power);
    }
    public override void Heal(float healing)
    {
        base.Heal(healing);
    }

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public float PlayerHealthProp
    {
        get { return playerHealth; }
    }
}
