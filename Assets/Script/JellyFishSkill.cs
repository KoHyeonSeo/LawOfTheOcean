using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/JellySkill")]
public class JellyFishSkill : Skill
{
    [SerializeField] private GameObject skillFactory;

    public override void UseSkill()
    {
        GameObject bullet = Instantiate(skillFactory);
        //bullet에게 User가 누구인지 알려줌
        bullet.GetComponent<TestBullet>().User = this.User;
        //bullet에게 Power가 어느정도인지 알려줌
        bullet.GetComponent<TestBullet>().BulletDamage = this.Power;
        bullet.transform.position = User.transform.position;
    }

    // Start is called before the first frame update

}
