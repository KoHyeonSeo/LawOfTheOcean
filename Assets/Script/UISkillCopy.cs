using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillCopy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI isSwapUseText;
    [SerializeField] private TextMeshProUGUI curSkillInfo;
    private GameObject swapUseObject;
    private GameObject curSkillInfoObject;
    private void Start()
    {
        swapUseObject = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        curSkillInfoObject = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        swapUseObject.SetActive(false);
        curSkillInfoObject.SetActive(true);
    }
    private void Update()
    {
        Debug.Log(GameManager.instance.IsStealUse);
        if (GameManager.instance.IsStealUse)
        {
            swapUseObject.SetActive(true);
        }
        else
        {
            swapUseObject.SetActive(false);
        }
        string str = "Copied Skill: ";
        str += GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skill.ToString();
        str += "\nCount: ";
        str+= GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skillCnt.ToString();
        curSkillInfo.text = str;
    }
}
