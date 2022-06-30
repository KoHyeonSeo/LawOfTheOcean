using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EntityHealth
{
    [SerializeField] private float enemyHealth = 100;
    private void Awake()
    {
        this.Health = enemyHealth;
        this.MaxHealth = enemyHealth;
    }
    public override void Damage(float power)
    {
        base.Damage(power);
    }
    public override void Heal(float healing)
    {
        base.Heal(healing);
    }
    public override float Health { get => base.Health; set => base.Health = value; }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
