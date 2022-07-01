using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySkill : MonoBehaviour
{
    //ScriptableObject로 만든 스킬과 스킬 발동될 확률 넣기
    [SerializeField] private List<Skill> skills;

    private List<float> perList;
    private bool isCallingComplete = true;

    private void Start()
    {
        float per = 0;
        foreach(var skill in skills)
        {
            Debug.Log($"{skill.name}");
            per += skill.Percentage;
            perList.Add(per);
        }
        if (per != 100)
        {
            Debug.LogError("퍼센트를 100으로 맞춰주세요.");
        }
    }
    private void Update()
    {
        if (isCallingComplete)
        {
            StartCoroutine("CallSkill");
        }
    }
    private IEnumerator CallSkill()
    {
        float randomNum = Random.Range(1, 101);
        isCallingComplete = false;
        int left = 0;
        int right = perList.Count;
        int mid = (left + right) / 2;
        while (left >= right)
        {
            if(perList[mid]<= randomNum)
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
        skills[mid].UseSkill();
        isCallingComplete = true;
        yield return new WaitForSeconds(5);
    }
}
