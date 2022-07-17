using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "EnemySkill/EnemySummonSkill")]
public class EnemySummonSkill : Skill
{
    // Start is called before the first frame update
    [SerializeField] private GameObject skillFactory;

    public override void UseSkill()
    {
        GameObject bullet = Instantiate(skillFactory);
        bullet.GetComponent<EnemySummon>().User = this.User;
        
        bullet.transform.position = User.transform.position;
    }
}
