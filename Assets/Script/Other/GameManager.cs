using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = new GameManager();
    private GameManager() { }
    public static GameManager getGameManager()
    {
        return instance;
    }
    
    
    //copy할 수 있는 스킬의 Max 값
    [SerializeField] private int skillMaxCnt = 10;

    [System.Serializable]
    public struct SkillInfo
    {
        public Skill skill;
        public int skillCnt;
    }
    //적 스킬 인덱스(갯수) 저장할 공간 필요할거 같다.
    //각 적의 스킬을 copy에서 사용할 시 PlayerSkillCopy에서 어떻게 사용할 수 있을까?
    [Header("Player가 copy한 Enemy Skill 갯수")]
    [SerializeField] private List<SkillInfo> skills = new List<SkillInfo>();

    /// <summary>
    /// skill과 카피가능 갯수를 구조체에 담아 리스트 형태로 반환하는 읽기 전용 프로퍼티
    /// [인덱스 정보]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    public List<SkillInfo> SkillList
    {
        get { return skills; }
    }

    /// <summary>
    /// 인덱스를 넣어 스킬을 증가시키는 쓰기 전용 프로퍼티 
    /// [인덱스 정보]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    public int SetIncreaseSkill
    {
        set
        {
            SkillInfo skill = skills[value];
            skill.skillCnt = skill.skillCnt >= skillMaxCnt ? skillMaxCnt : skill.skillCnt + 1;
        }
    }

    /// <summary>
    /// 인덱스를 넣어 스킬을 감소시키는 쓰기 전용 프로퍼티
    /// [인덱스 정보]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    public int SetDecreaseSkill
    {
        set
        {
            SkillInfo skill = skills[value];
            skill.skillCnt = skill.skillCnt >= skillMaxCnt ? skillMaxCnt : skill.skillCnt - 1;
        }
    }
}
