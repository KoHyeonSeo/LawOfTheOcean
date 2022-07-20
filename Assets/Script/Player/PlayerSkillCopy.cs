using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//copy한 스킬 사용
public class PlayerSkillCopy : MonoBehaviour
{
    [SerializeField] private AudioClip useSkillClip;
    private PlayerInput player;
    private AudioSource source;
    private void Awake()
    {
        player = GetComponent<PlayerInput>();
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //스킬 swap
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
            //스킬 갯수를 고려하여 사용
            if (GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skillCnt == 0)
            {
                Debug.Log("사용 불가");
            }
            else
            {
                GameManager.instance.SetDecreaseSkill = GameManager.instance.StealCopyCurIndex;
                //User정보 업데이트
                GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skill.User = gameObject;
                //카피한 스킬 사용
                GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skill.UseSkill();
            }
            //스킬은 enemy를 죽였을 때 확률적으로 얻기
        }
        if (GameManager.instance.IsStealUse)
        {
            source.PlayOneShot(useSkillClip);
        }
    }


}
