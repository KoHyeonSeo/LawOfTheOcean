using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//copy한 스킬 사용
public class PlayerSkillCopy : MonoBehaviour
{
    [SerializeField] private int curIndex = 0;
    private PlayerShooter player;
    private void Awake()
    {
        player = GetComponent<PlayerShooter>();
    }

    private void Update()
    {
        //스킬 swap
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
            //스킬 갯수를 고려하여 사용
            if (GameManager.instance.SkillList[curIndex].skillCnt == 0)
            {
                Debug.Log("사용 불가");
            }
            else
            {
                GameManager.instance.SetDecreaseSkill = curIndex;
                //User정보 업데이트
                GameManager.instance.SkillList[curIndex].skill.User = gameObject;
                //카피한 스킬 사용
                GameManager.instance.SkillList[curIndex].skill.UseSkill();
            }
            //스킬은 enemy를 죽였을 때 확률적으로 얻기
        }
        
    }


}
