using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillCopy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI isSwapUseText;
    [SerializeField] private TextMeshProUGUI curSkillInfo;
    [SerializeField] private TextMeshProUGUI maxSkillError;
    [SerializeField] private Slider skillSlider;
    [SerializeField] private float reportTime = 1.5f;

    private GameObject swapUseObject;
    private GameObject curSkillInfoObject;
    private GameObject sliderObject;
    private GameObject reportObject;
    private float speed = 2;
    private bool next = false;
    private float curTime = 0;

    private void Start()
    {
        curTime = 0;
        swapUseObject = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        curSkillInfoObject = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        sliderObject = gameObject.transform.GetChild(0).GetChild(2).gameObject;
        reportObject = gameObject.transform.GetChild(0).GetChild(3).gameObject;

        swapUseObject.SetActive(false);
        curSkillInfoObject.SetActive(true);
        sliderObject.SetActive(false);
        reportObject.SetActive(false);
    }
    private void Update()
    {
        if (UIManager.instance.IsOrbMoving && !GameManager.instance.IsSkillMaxCountError)
        {
            sliderObject.SetActive(true);
            StartCoroutine("SliderMoving");
            UIManager.instance.IsOrbMoving = false;
        }
        if (GameManager.instance.IsStealUse)
        {
            swapUseObject.SetActive(true);
        }
        else
        {
            swapUseObject.SetActive(false);
        }
        if (GameManager.instance.IsSkillMaxCountError)
        {
            reportObject.SetActive(true);
            
            curTime += Time.deltaTime;
            if (curTime >= reportTime)
            {
                curTime = 0;
                reportObject.SetActive(false);
                GameManager.instance.IsSkillMaxCountError = false;
            }
        }
        string str = "Copied Skill: ";
        str += GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skill.ToString();
        str += "\nCount: ";
        str+= GameManager.instance.SkillList[GameManager.instance.StealCopyCurIndex].skillCnt.ToString();
        curSkillInfo.text = str;
    }
    
    private IEnumerator SliderMoving()
    {
        while (true)
        {
            if (!next)
            {
                skillSlider.value += speed * Time.deltaTime;
                if (skillSlider.value >= 1)
                {
                    skillSlider.value = 1;
                    next = true;
                }
            }
            else
            {
                skillSlider.value -= speed * Time.deltaTime;
                if (skillSlider.value <= 0)
                {
                    skillSlider.value = 0;
                    next = false;

                    sliderObject.SetActive(false);
                    yield break;
                }
            }
            yield return null;
        }
    }
}
