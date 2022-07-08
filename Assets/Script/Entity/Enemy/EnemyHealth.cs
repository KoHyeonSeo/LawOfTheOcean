using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : EntityHealth
{
    [SerializeField] private float enemyHealth = 100;
    private StolenSkill stolenSkill;
    private void Awake()
    {
        this.DeadCheck = false;
        this.Health = enemyHealth;
        this.MaxHealth = enemyHealth;
        stolenSkill = GetComponent<StolenSkill>();
    }
    public override void Damage(float power)
    {
        Health -= power;
        if (currentHealth <= 0f && !DeadCheck)
        {
            Die();
        }
        else if(GameManager.instance.IsStealUse && !DeadCheck)
        {
            GameManager.instance.IsStealUse = false;
        }
    }
    public override void Heal(float healing)
    {
        base.Heal(healing);
    }

    protected override void Die()
    {
        base.Die();
        if (GameManager.instance.IsStealUse)
        {
            if (gameObject.GetComponent<EnemySkill>().skills.Count == 1)
            {
                for(int j = 0; j < GameManager.instance.SkillList.Count; j++)
                {
                    var skill = GameManager.instance.SkillList[j];
                    if (skill.skill == gameObject.GetComponent<EnemySkill>().skills[0].skill)
                    {
                        GameManager.instance.SetIncreaseSkill = j;
                    }
                }

            }
        }
        else
        {
            EnemyDestroy();
        }
    }
    public void EnemyDestroy()
    {
        Destroy(gameObject);
    }

    public float EnemyHealthProp
    {
        get
        {
            return enemyHealth;
        }
    }
}
