using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/BlowFishSkill")]
public class BlowFishSkill : Skill
{
    [SerializeField] private GameObject bulletFactory;
    //To do 
    //1. 오브젝트 풀 만들기
    //2. 다양한 각도에서 발사하기

    public override void UseSkill()
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.GetComponent<ThornBullet>().BulletUser = User;
        bullet.GetComponent<ThornBullet>().BulletDamage = Power;
        bullet.GetComponent<ThornBullet>().BulletDir = Vector3.forward;
        bullet.transform.position = User.transform.position;
    }
}
