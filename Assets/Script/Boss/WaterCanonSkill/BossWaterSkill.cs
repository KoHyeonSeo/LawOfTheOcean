using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/BossWaterSkill")]
public class BossWaterSkill : Skill
{
    [SerializeField] private GameObject waterCanonPrefab;
    [SerializeField] private int bulletCount = 100;
    private Vector3 dir;
    public override void UseSkill()
    {
        float deltaAngle = 100 / bulletCount;
        dir = Vector3.up;
        for (int i = 1; i <= bulletCount; i++)
        {
            GameObject water = Instantiate(waterCanonPrefab);

            water.GetComponent<WaterBullet>().BulletUser = User;
            water.GetComponent<WaterBullet>().BulletDamage = Power;
            dir = Quaternion.Euler(0, 0, deltaAngle + 90) * dir;
            water.transform.up = dir;
            water.transform.position = User.transform.position + new Vector3(0,20,0);
            water.GetComponent<Rigidbody>().AddForce(dir.normalized * 1000,ForceMode.Force);


            GameObject water2 = Instantiate(waterCanonPrefab);

            water2.GetComponent<WaterBullet>().BulletUser = User;
            water2.GetComponent<WaterBullet>().BulletDamage = Power;
            dir = Quaternion.Euler(0, deltaAngle + 90, 0) * dir;
            water2.transform.up = dir;
            water.transform.position = User.transform.position + new Vector3(0, 20, 0);
            water2.GetComponent<Rigidbody>().AddForce(dir.normalized * 1000, ForceMode.Force);


            GameObject water3 = Instantiate(waterCanonPrefab);

            water3.GetComponent<WaterBullet>().BulletUser = User;
            water3.GetComponent<WaterBullet>().BulletDamage = Power;
            dir = Quaternion.Euler(deltaAngle + 90, 0, 0) * dir;
            water3.transform.up = dir;
            water.transform.position = User.transform.position + new Vector3(0, 20, 0);
            water3.GetComponent<Rigidbody>().AddForce(dir.normalized * 1000, ForceMode.Force);

        }
    }

}
