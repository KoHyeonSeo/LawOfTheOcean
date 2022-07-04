using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//copy한 스킬 사용
public class PlayerSkillCopy : MonoBehaviour
{
    [SerializeField] private int curIndex = 0;
    // UI에 tab눌러서 스킬 swap 예정
    // UI에 어떤 스킬인지 나타낼려면 어떻게 해야할까
    // 1. Dictionary 형태로 해당 key(아마 skillInfo의 index)의 value(skill이름)을 UI이름과 똑같이? 해서 setActive해야할까
    //      -> find 사용 (성능 저하) 말고 해당 UI를 알아낼 수 있는 다른 방법이 있을까 
    // 2. 아예 끼워넣는 방식으로 할까 (개발자가 할 일이 많아짐)
    // 3. UIManager에게 정보 전달 -> 이게 좋은 방법이지 않을까..?
    //      -> UIManager에 해당 인덱스 전달 후 UIManager에서 해당 UI를 setActive


    private void Update()
    {
        if (Input.GetButtonDown("Swap"))
        {
            if(curIndex == GameManager.instance.SkillList.Count - 1)
            {
                curIndex = 0;
            }
            else
            {
                curIndex++;
            }
            
        }
        if (Input.GetButtonDown("Use Skill"))
        {
            //나중에는 스킬 갯수도 고려
            //GameManager.instance.SkillList[curIndex].skill.UseSkill();
            
            //스킬은 enemy를 죽였을 때 확률적으로 얻기
        }
    }


}
