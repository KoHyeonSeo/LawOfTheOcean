using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySkill : MonoBehaviour
{

    [Serializable]
    //스킬의 정보를 넣을 구조체 생성
    public struct SkillSystem
    {
        public Skill skill;
        public float percent;
    }

    [Header("스킬")]
    public List<SkillSystem> skills;
    //각 스킬의 확률범위 중 끝부분을 넣는 리스트
    private List<float> perList = new List<float>();
    //CallSkill 코루틴이 실행되기 위한 부울 플래그
    private bool isCallingComplete = true;
    //error나올 때 나타내는 부울 플래그
    private bool isError = false;

    private int mid;
    //ScriptableObject로 만든 스킬과 스킬 발동될 확률 넣기
    private void Start()
    {
        float per = 0;
        foreach (var skill in skills)
        {
            per += skill.percent;
            perList.Add(per);
        }
        if (per != 1)
        {
            Debug.LogError("퍼센트의 합은 1이 되어야합니다.");
        }
    }
    private void Update()
    {
        //Callskill을 한번씩 스킬 발동 후 쓰고 싶다.
        if (isCallingComplete && !isError)
        {
            StartCoroutine("CallSkill");
        }
    }
    private IEnumerator CallSkill()
    {
        //랜덤 수 얻기
        float randomNum = Random.Range(0.0f, 1.0f);
        isCallingComplete = false;

        //어느 범위에 해당되는 스킬인지 알고 싶다.
        int left = 0;
        int right = perList.Count - 1;
        mid = (left + right) / 2;
        while (mid < right)
        {
            if (perList[mid] <= randomNum)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
            mid = (left + right) / 2;
            yield return null;
        }
        //User정보 등록
        skills[mid].skill.User = gameObject;
        //그 해당되는 스킬을 사용하고 싶다.
        skills[mid].skill.UseSkill();
        //그 해당되는 스킬의 쿨타임만큼 기다린다.
        yield return new WaitForSeconds(skills[mid].skill.CoolTime);

        isCallingComplete = true;
    }
}
