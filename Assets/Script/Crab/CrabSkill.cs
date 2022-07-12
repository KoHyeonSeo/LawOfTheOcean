using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/CrabSkill")]
public class CrabSkill : Skill
{
    [SerializeField] private GameObject skillFactory;

    public override void UseSkill()
    {
        GameObject bullet = Instantiate(skillFactory);
        bullet.GetComponent<CrabBullet>().User = this.User;
        bullet.GetComponent<CrabBullet>().BulletDamage = this.Power;
        bullet.transform.position = User.transform.position;
    }
}


