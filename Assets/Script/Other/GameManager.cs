using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    private struct EnemySkillInfo
    {
        public Skill skillName;
        public int skillCnt;
    }
    Dictionary<string, int> skillInfo = new Dictionary<string, int>();
    //적 스킬 인덱스(갯수) 저장할 공간 필요할거 같다.
    //각 적의 스킬을 copy에서 사용할 시 PlayerSkillCopy에서 어떻게 사용할 수 있을까?
    [Header("Player가 copy한 Enemy Skill 갯수")]
    [SerializeField] private List<EnemySkillInfo> enemySkillInfos = new List<EnemySkillInfo>();

    private int enemySkillNum;
    public static GameManager instance = new GameManager();
    private GameManager() { }
    public static GameManager getGameManager()
    {
        return instance;
    }
    public Dictionary<string,int> SkillProp
    {
        set
        {

        }
    }
    //적 스킬 갯수
    public int EnemySkillNum
    {
        get
        {
            return enemySkillNum;
        }
        set
        {
            enemySkillNum = value < 0 ? 0 : value;
            
        }
    }
}
