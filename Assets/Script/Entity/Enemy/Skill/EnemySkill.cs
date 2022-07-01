using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySkill : MonoBehaviour
{
    //ScriptableObject로 만든 스킬과 스킬 발동될 확률 넣기
    [SerializeField] private List<Skill> skills;
    //각 스킬의 확률범위 중 끝부분을 넣는 리스트
    private List<float> perList = new List<float>();
    //CallSkill 코루틴이 실행되기 위한 부울 플래그
    private bool isCallingComplete = true;
    //error나올 때 나타내는 부울 플래그
    private bool isError = false;
    private int mid;

    private void Start()
    {
        //각 스킬의 확률 범위 중 끝범위 리스트에 넣기
        float per = 0;
        foreach(var skill in skills)
        {
            per += skill.Percentage;
            perList.Add(per);
        }
        //모든 확률의 퍼센트가 100이 아닐 때, 에러창 
        if (per != 100)
        {
            Debug.LogError("퍼센트를 100으로 맞춰주세요.");
            isError = true;
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
        float randomNum = Random.Range(1, 101);

        isCallingComplete = false;

        //어느 범위에 해당되는 스킬인지 알고 싶다.
        int left = 0;
        int right = perList.Count - 1;
        mid = (left + right) / 2;
        while (mid >= right)
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
        //그 해당되는 스킬을 사용하고 싶다.
        skills[mid].UseSkill();
        yield return new WaitForSeconds(5);

        isCallingComplete = true;
    }
}
