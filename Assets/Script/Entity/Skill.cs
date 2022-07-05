using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [Header("스킬 속성")]
    [SerializeField] private float power;
    [SerializeField] private float cooltime;
    private GameObject user;


    /// <summary>
    /// 스킬 쿨타임 프로퍼티
    /// </summary>
    public float CoolTime { get { return cooltime; } set { cooltime = value; } }
    /// <summary>
    /// 스킬 데미지
    /// </summary>
    public float Power { get { return power; } set { power = value; } }

    /// <summary>
    /// 유저 정보 프로퍼티 EnemySkill에서 사용자 오브젝트 자동 저장
    /// </summary>
    public GameObject User { get { return user; } set { user = value; } }
    public abstract void UseSkill();
}
