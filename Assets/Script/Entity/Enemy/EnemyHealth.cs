using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EntityHealth
{
    [SerializeField] private float enemyHealth = 100;
    private void Awake()
    {
        this.DeadCheck = false;
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

    protected override void Die()
    {
        base.Die();
        if (GameManager.instance.StealSkillButton)
        {
            if (gameObject.GetComponent<EnemySkill>().skills.Count == 1)
            {
                int i = 0;
                foreach (var skill in GameManager.instance.SkillList)
                {
                    //Debug.Log($"Steal: {skill.skill == gameObject.GetComponent<EnemySkill>().skills[0].skill}");
                    if (skill.skill == gameObject.GetComponent<EnemySkill>().skills[0].skill)
                    {
                        //Debug.Log($"Steal: {skill.skill}");
                        var sk = GameManager.instance.SkillList[i];
                        sk.skillCnt++;
                        GameManager.instance.SkillList[i] = sk;
                    }
                    i++;
                }
            }
        }
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
