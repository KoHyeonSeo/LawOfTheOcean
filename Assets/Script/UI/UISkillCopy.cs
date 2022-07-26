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

    private ScreenSize curScreen;
    struct ScreenSize
    {
        public float width;
        public float height;
    }
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

        curScreen.width = Screen.width;
        curScreen.height = Screen.height; 

        effect1.initial = new Vector3(Screen.width / 2, Screen.height - Screen.height / 7, 0);
        effect2.initial = new Vector3(Screen.width / 2, Screen.height / 7, 0);
        effect3.initial = new Vector3(Screen.width / 14, Screen.height / 2, 0);
        effect4.initial = new Vector3(Screen.width - Screen.width / 14, Screen.height / 2, 0);

        skillEffect1 = skillUseObject.transform.GetChild(0).gameObject;
        skillEffect2 = skillUseObject.transform.GetChild(1).gameObject;
        skillEffect3 = skillUseObject.transform.GetChild(2).gameObject;
        skillEffect4 = skillUseObject.transform.GetChild(3).gameObject;

        effect1.afterPosition = skillEffect1.transform.position + new Vector3(0, Screen.height / 2, 0);
        effect2.afterPosition = skillEffect2.transform.position + new Vector3(0, -Screen.height / 2, 0);
        effect3.afterPosition = skillEffect3.transform.position + new Vector3(-Screen.width / 2, 0, 0);
        effect4.afterPosition = skillEffect4.transform.position + new Vector3(Screen.width / 2, 0, 0);


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
        if(Screen.width != curScreen.width || Screen.height != curScreen.height)
        {
            curScreen.width = Screen.width;
            curScreen.height = Screen.height;

            effect1.initial = new Vector3(Screen.width / 2, Screen.height - Screen.height / 7, 0);
            effect2.initial = new Vector3(Screen.width / 2, Screen.height / 7, 0);
            effect3.initial = new Vector3(Screen.width / 14, Screen.height / 2, 0);
            effect4.initial = new Vector3(Screen.width - Screen.width / 14, Screen.height / 2, 0);

            effect1.afterPosition = skillEffect1.transform.position + new Vector3(0, Screen.height / 2, 0);
            effect2.afterPosition = skillEffect2.transform.position + new Vector3(0, -Screen.height / 2, 0);
            effect3.afterPosition = skillEffect3.transform.position + new Vector3(-Screen.width / 2, 0, 0);
            effect4.afterPosition = skillEffect4.transform.position + new Vector3(Screen.width / 2, 0, 0);
        }
        if (UIManager.instance.IsOrbMoving && !GameManager.instance.IsSkillMaxCountError)
        {
            sliderObject.SetActive(true);
            StartCoroutine("SliderMoving");
            UIManager.instance.IsOrbMoving = false;
        }
        if (GameManager.instance.IsStealUse)
        {
            //skillUseObject.SetActive(true);
            skillEffect1.transform.position = Vector2.Lerp(skillEffect1.transform.position,effect1.initial, 0.02f);
            skillEffect2.transform.position = Vector2.Lerp(skillEffect2.transform.position, effect2.initial, 0.02f);
            skillEffect3.transform.position = Vector2.Lerp(skillEffect3.transform.position, effect3.initial, 0.02f);
            skillEffect4.transform.position = Vector2.Lerp(skillEffect4.transform.position, effect4.initial, 0.02f);
          
        }
        else 
        {
            skillEffect1.transform.position = Vector2.Lerp(skillEffect1.transform.position,effect1.afterPosition , 0.005f);
            skillEffect2.transform.position = Vector2.Lerp(skillEffect2.transform.position, effect2.afterPosition, 0.005f);
            skillEffect3.transform.position = Vector2.Lerp(skillEffect3.transform.position, effect3.afterPosition, 0.005f);
            skillEffect4.transform.position = Vector2.Lerp(skillEffect4.transform.position, effect4.afterPosition, 0.005f);
               
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
