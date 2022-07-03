using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //적 스킬 인덱스 저장할 공간 필요할거 같다.
    //각 적의 스킬을 copy에서 사용할 시 PlayerSkillCopy에서 어떻게 사용할 수 있을까?

    private int enemySkillNum;
    public static GameManager instance = new GameManager();
    private GameManager(){ }
    public static GameManager getGameManager()
    {
        return instance;
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
