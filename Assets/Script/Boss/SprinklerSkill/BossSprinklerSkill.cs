using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/BossSprinkerSkill")]
public class BossSprinklerSkill : Skill
{
    [SerializeField] private GameObject bulletFactory;
    [SerializeField] private int bulletCount = 100;

    public override void UseSkill()
    {
        for (int i = 1; i <= bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);


        }
    }

}
