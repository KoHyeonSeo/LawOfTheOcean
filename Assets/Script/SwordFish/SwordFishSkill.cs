using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/SwordFishSkill")]
public class SwordFishSkill : Skill
{
    [SerializeField] private GameObject useSkillFactory;

    public override void UseSkill()
    {
        GameObject useSkill = Instantiate(useSkillFactory);
        useSkill.GetComponent<SwordFishUseSkill>().UseSkill = true;
        useSkill.GetComponent<SwordFishUseSkill>().SkillUser = User;
        useSkill.GetComponent<SwordFishUseSkill>().SkillCoolTime = CoolTime;
    }
}