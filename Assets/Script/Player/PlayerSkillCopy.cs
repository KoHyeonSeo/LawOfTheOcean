using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//copy�� ��ų ���
public class PlayerSkillCopy : MonoBehaviour
{
    private PlayerInput player;
    private void Awake()
    {
        player = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        //��ų swap
        if (player.SwapButton)
        {
            if(GameManager.instance.StealCopyCurIndex == GameManager.instance.SkillList.Count - 1)
            {
                GameManager.instance.StealCopyCurIndex = 0;
            }
            else
            {
                GameManager.instance.StealCopyCurIndex++;
            }
            
        }
        if (player.CopiedSkillUseButton)
        {
            //��ų ������ �����Ͽ� ���
            if (GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skillCnt == 0)
            {
                Debug.Log("��� �Ұ�");
            }
            else
            {
                GameManager.instance.SetDecreaseSkill = GameManager.instance.StealCopyCurIndex;
                //User���� ������Ʈ
                GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skill.User = gameObject;
                //ī���� ��ų ���
                GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skill.UseSkill();
            }
            //��ų�� enemy�� �׿��� �� Ȯ�������� ���
        }
        
    }


}