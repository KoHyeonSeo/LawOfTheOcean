using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [Header("스킬 속성")]
    [SerializeField] private float power;
    [SerializeField] private float cooltime;
    public float CoolTime { get { return cooltime; } set { cooltime = value; } }
    public float Power { get { return power; } set { power = value; } }

    public abstract void UseSkill();
}
