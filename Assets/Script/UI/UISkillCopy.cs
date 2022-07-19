using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillCopy : MonoBehaviour
{
    [SerializeField] private GameObject jellyFishTemp;
    [SerializeField] private GameObject blowFishTemp;
    [SerializeField] private GameObject crabTemp;
    [SerializeField] private GameObject blueMarlinTemp;

    [SerializeField] private Slider skillSlider;
    [SerializeField] private float reportTime = 1.5f;

    private Text jellyFishValue;
    private Text blowValue;
    private Text crabValue;
    private Text blueMarlinValue;

    private GameObject jellyChoice;
    private GameObject blowChoice;
    private GameObject crabChoice;
    private GameObject blueMarlinChoice;

    private GameObject skillEffect1;
    private GameObject skillEffect2;
    private GameObject skillEffect3;
    private GameObject skillEffect4;

    private GameObject sliderObject;
    private GameObject reportObject;
    private GameObject skillUseObject;
    private float speed = 2;
    private bool next = false;
    private float curTime = 0;
    struct effectPosition
    {
        public Vector3 initial;
        public Vector3 afterPosition;
    }
    effectPosition effect1;
    effectPosition effect2;
    effectPosition effect3;
    effectPosition effect4;
    private void Start()
    {
        curTime = 0;

        jellyFishValue = jellyFishTemp.transform.GetChild(0).GetComponent<Text>();
        blowValue = blowFishTemp.transform.GetChild(0).GetComponent<Text>();
        crabValue = crabTemp.transform.GetChild(0).GetComponent<Text>();
        blueMarlinValue = blueMarlinTemp.transform.GetChild(0).GetComponent<Text>();

        jellyChoice = jellyFishTemp.transform.GetChild(2).gameObject;
        blowChoice = blowFishTemp.transform.GetChild(2).gameObject;
        crabChoice = crabTemp.transform.GetChild(2).gameObject;
        blueMarlinChoice = blueMarlinTemp.transform.GetChild(2).gameObject;
        skillUseObject = gameObject.transform.GetChild(0).GetChild(0).gameObject;

        skillEffect1 = skillUseObject.transform.GetChild(0).gameObject;
        skillEffect2 = skillUseObject.transform.GetChild(1).gameObject;
        skillEffect3 = skillUseObject.transform.GetChild(2).gameObject;
        skillEffect4 = skillUseObject.transform.GetChild(3).gameObject;


        effect1.initial = skillEffect1.transform.position;
        effect2.initial = skillEffect2.transform.position;
        effect3.initial = skillEffect3.transform.position;
        effect4.initial = skillEffect4.transform.position;

        effect1.afterPosition = skillEffect1.transform.position + new Vector3(0, 500, 0);
        effect2.afterPosition = skillEffect2.transform.position + new Vector3(0, -500, 0);
        effect3.afterPosition = skillEffect3.transform.position + new Vector3(-500, 0, 0);
        effect4.afterPosition = skillEffect4.transform.position + new Vector3(500, 0, 0);

        skillEffect1.transform.position = effect1.afterPosition;
        skillEffect2.transform.position = effect2.afterPosition;
        skillEffect3.transform.position = effect3.afterPosition;
        skillEffect4.transform.position = effect4.afterPosition;

        sliderObject = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        reportObject = gameObject.transform.GetChild(0).GetChild(2).gameObject;

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
            //skillUseObject.SetActive(true);
            skillEffect1.transform.position = Vector2.Lerp(skillEffect1.transform.position,effect1.initial, Time.deltaTime);
            skillEffect2.transform.position = Vector2.Lerp(skillEffect2.transform.position, effect2.initial, Time.deltaTime);
            skillEffect3.transform.position = Vector2.Lerp(skillEffect3.transform.position, effect3.initial, Time.deltaTime);
            skillEffect4.transform.position = Vector2.Lerp(skillEffect4.transform.position, effect4.initial, Time.deltaTime);
          
        }
        else 
        {
            skillEffect1.transform.position = Vector2.Lerp(skillEffect1.transform.position,effect1.afterPosition , Time.deltaTime);
            skillEffect2.transform.position = Vector2.Lerp(skillEffect2.transform.position, effect2.afterPosition, Time.deltaTime);
            skillEffect3.transform.position = Vector2.Lerp(skillEffect3.transform.position, effect3.afterPosition, Time.deltaTime);
            skillEffect4.transform.position = Vector2.Lerp(skillEffect4.transform.position, effect4.afterPosition, Time.deltaTime);
               
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
        switch (GameManager.instance.StealCopyCurIndex)
        {
            case 0:
                jellyChoice.SetActive(true);
                blowChoice.SetActive(false);
                crabChoice.SetActive(false);
                blueMarlinChoice.SetActive(false);
                break;
            case 1:
                jellyChoice.SetActive(false);
                blowChoice.SetActive(true);
                crabChoice.SetActive(false);
                blueMarlinChoice.SetActive(false);
                break;
            case 2:
                jellyChoice.SetActive(false);
                blowChoice.SetActive(false);
                crabChoice.SetActive(true);
                blueMarlinChoice.SetActive(false);
                break;
            case 3:
                jellyChoice.SetActive(false);
                blowChoice.SetActive(false);
                crabChoice.SetActive(false);
                blueMarlinChoice.SetActive(true);
                break;
        }


        jellyFishValue.text = GameManager.instance.SkillList[0].skillCnt.ToString();
        blowValue.text = GameManager.instance.SkillList[1].skillCnt.ToString();
        crabValue.text = GameManager.instance.SkillList[2].skillCnt.ToString();
        blueMarlinValue.text = GameManager.instance.SkillList[3].skillCnt.ToString();
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
