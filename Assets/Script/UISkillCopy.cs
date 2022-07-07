using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillCopy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI isSwapUseText;
    [SerializeField] private TextMeshProUGUI curSkillInfo;
    [SerializeField] private Slider skillSlider;
    private GameObject swapUseObject;
    private GameObject curSkillInfoObject;
    private GameObject sliderObject;
    private float speed = 2;
    private bool next = false;
    private void Start()
    {
        swapUseObject = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        curSkillInfoObject = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        sliderObject = gameObject.transform.GetChild(0).GetChild(2).gameObject;
        swapUseObject.SetActive(false);
        curSkillInfoObject.SetActive(true);
        sliderObject.SetActive(false);
    }
    private void Update()
    {
        if (UIManager.instance.IsOrbMoving)
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
