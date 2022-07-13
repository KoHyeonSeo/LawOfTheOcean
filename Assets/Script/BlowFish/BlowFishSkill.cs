using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/BlowFishSkill")]
public class BlowFishSkill : Skill
{
    [SerializeField] private GameObject bulletFactory;
    [SerializeField] private int bulletCount = 10;
    //To do 
    //1. 다양한 각도에서 발사하기

    public override void UseSkill()
    {

        int deltaAngle = 360 / bulletCount;
        Vector3 dir = Vector3.up;
        for (int i = 1; i <= bulletCount; i++)
        {
            //up

            //1. 총알이 필요하다.
            GameObject bullet = Instantiate(bulletFactory);
            //2. 발사할 방향을 정하고 싶다.
            //bullet.transform.eulerAngles = new Vector3(0, 0, deltaAngle * i);
            dir = Quaternion.Euler(0, 0, deltaAngle) * dir;
            bullet.transform.up = dir;
            //3. 총알 하나 발사하고 싶다.
            bullet.transform.position = User.transform.position;


            //forward

            //1. 총알이 필요하다.
            GameObject bullet2 = Instantiate(bulletFactory);
            bullet2.GetComponent<ThornBullet>().BulletUser = User;
            bullet2.GetComponent<ThornBullet>().BulletDamage = Power;
            //2. 발사할 방향을 정하고 싶다.
            bullet2.transform.rotation = Quaternion.Euler(0, 0, deltaAngle * i);
            //3. 총알 하나 발사하고 싶다.
            bullet2.transform.position = User.transform.position;


            //right

            //1. 총알이 필요하다.
            GameObject bullet3 = Instantiate(bulletFactory);
            bullet3.GetComponent<ThornBullet>().BulletUser = User;
            bullet3.GetComponent<ThornBullet>().BulletDamage = Power;
            //2. 발사할 방향을 정하고 싶다.
            bullet3.transform.rotation = Quaternion.Euler(deltaAngle * i, 0, 0);
            //3. 총알 하나 발사하고 싶다.
            bullet3.transform.position = User.transform.position;
        }

    }
}
