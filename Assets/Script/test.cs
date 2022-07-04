using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "EnemySkill/testSkill")]
public class test : Skill
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform user;
    public override void UseSkill()
    {

        GameObject bulletPre = Instantiate(bullet);
        bulletPre.transform.position = user.position;
    }

}
