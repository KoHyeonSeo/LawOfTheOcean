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
            //Debug.Log("¾ÈÁ×À½ StealUse = false");
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
                    //Debug.Log($"Steal: {skill.skill == gameObject.GetComponent<EnemySkill>().skills[0].skill}");
                    if (skill.skill == gameObject.GetComponent<EnemySkill>().skills[0].skill)
                    {
                        //Debug.Log($"Steal: {skill.skill}");
                        GameManager.instance.SetIncreaseSkill = j;
                        //Debug.Log("5");
                    }
                    //Debug.Log("4");
                }
                #region Obsolete
                //int i = 0;
                //foreach (var skill in GameManager.instance.SkillList)
                //{
                //    //Debug.Log($"Steal: {skill.skill == gameObject.GetComponent<EnemySkill>().skills[0].skill}");
                //    if (skill.skill == gameObject.GetComponent<EnemySkill>().skills[0].skill)
                //    {
                //        //Debug.Log($"Steal: {skill.skill}");
                //        GameManager.instance.SetIncreaseSkill = i;
                //        Debug.Log("5");
                //    }
                //    i++;
                //    Debug.Log("4");
                //}
                #endregion
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
