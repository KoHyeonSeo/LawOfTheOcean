using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] private float power;
    [SerializeField] private float cooltime;
    [SerializeField] private float percentage;
    public float CoolTime { get { return cooltime; } set { cooltime = value; } }
    public float Power { get { return power; } set { power = value; } }
    public float Percentage { get { return percentage; } set { percentage = value; } }
    
    public virtual void UseSkill(){ }
}
