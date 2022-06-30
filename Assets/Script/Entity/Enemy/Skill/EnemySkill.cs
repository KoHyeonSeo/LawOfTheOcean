using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemySkill : ScriptableObject
{
    public string skillName = "skill";

    public virtual void UseSkill(GameObject target)
    {

    }
}
