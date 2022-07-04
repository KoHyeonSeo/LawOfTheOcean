using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//copy�� ��ų ���
public class PlayerSkillCopy : MonoBehaviour
{
    [SerializeField] private int curIndex = 0;

    private void Update()
    {
        //��ų swap
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
            //��ų ������ �����Ͽ� ���
            if (GameManager.instance.SkillList[curIndex].skillCnt == 0)
            {
                Debug.Log("��� �Ұ�");
            }
            else
            {
                GameManager.instance.SetDecreaseSkill = curIndex;
                GameManager.instance.SkillList[curIndex].skill.UseSkill();
            }
            //��ų�� enemy�� �׿��� �� Ȯ�������� ���
        }
    }


}