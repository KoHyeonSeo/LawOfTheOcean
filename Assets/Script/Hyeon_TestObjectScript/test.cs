using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "EnemySkill/testSkill")]
public class test : Skill
{
    [SerializeField] private GameObject bullet;
    
    public override void UseSkill()
    {
        //bullet 생성
        GameObject bulletPre = Instantiate(bullet);
        //bullet에게 User가 누구인지 알려줌
        bulletPre.GetComponent<TestBullet>().User = this.User;
        //bullet에게 Power가 어느정도인지 알려줌
        bulletPre.GetComponent<TestBullet>().BulletDamage = this.Power;
        //bullet 생성위치
        bulletPre.transform.position = User.transform.position;
    }
}
