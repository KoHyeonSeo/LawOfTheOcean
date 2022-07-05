using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "EnemySkill/testSkill")]
public class test : Skill
{
    [SerializeField] private GameObject bullet;
    public override void UseSkill()
    {
        GameObject bulletPre = Instantiate(bullet);
        bulletPre.transform.position = User.transform.position;
    }

}
