using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillCopy : MonoBehaviour
{
    //[System.Serializable]
    //private struct SkillInfo
    //{
    //    public Skill enemySkill;
    //    public int skillCnt;
    //}
    //[Header("사용 가능 스킬 갯수")]
    //[SerializeField] private List<SkillInfo> skillList = new List<SkillInfo>();


    // UI에 tab눌러서 스킬 swap 예정
    // UI에 어떤 스킬인지 나타낼려면 어떻게 해야할까
    // 1. Dictionary 형태로 해당 key(아마 skillInfo의 index)의 value(skill이름)을 UI이름과 똑같이? 해서 setActive해야할까
    //      -> find 사용 (성능 저하) 말고 해당 UI를 알아낼 수 있는 다른 방법이 있을까 
    // 2. 아예 끼워넣는 방식으로 할까 (개발자가 할 일이 많아짐)
    // 3. UIManager에게 정보 전달 -> 이게 좋은 방법이지 않을까..?
    //      -> UIManager에 해당 인덱스 전달 후 UIManager에서 해당 UI를 setActive
    
    
}
