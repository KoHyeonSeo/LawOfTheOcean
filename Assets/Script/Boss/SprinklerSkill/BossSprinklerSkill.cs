using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/BossSprinkerSkill")]
public class BossSprinklerSkill : Skill
{
    [SerializeField] private GameObject firePos;
    [SerializeField] private GameObject firePos2;

    public override void UseSkill()
    {
        Bounds bounds = User.GetComponent<Collider>().bounds;

        GameObject fire = Instantiate(firePos);
        fire.GetComponent<BossFirePos>().SkillDamage = Power;
        fire.GetComponent<BossFirePos>().SkillUser = User;
        fire.transform.position = new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);

        GameObject fire2 = Instantiate(firePos2);
        fire2.GetComponent<BossFirePos>().SkillDamage = Power;
        fire2.GetComponent<BossFirePos>().SkillUser = User;
        fire2.transform.position = new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);
    }

}
