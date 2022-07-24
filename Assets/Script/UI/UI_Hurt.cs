using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Hurt : MonoBehaviour
{

    private GameObject skillEffect1;
    private GameObject skillEffect2;
    private GameObject skillEffect3;
    private GameObject skillEffect4;
    struct effectPosition
    {
        public Vector3 initial;
        public Vector3 afterPosition;
    }
    struct ScreenSize
    {
        public float width;
        public float height;
    }

    effectPosition effect1;
    effectPosition effect2;
    effectPosition effect3;
    effectPosition effect4;

    private ScreenSize curScreen;

    private GameObject hurtObject;

    private PlayerHealth playerHealth;

    private float hurtTime = 0.5f;
    private float curTime = 0;
    private void Start()
    {
        playerHealth = UIManager.instance.PlayerObject.GetComponent<PlayerHealth>();    
        hurtObject = gameObject.transform.GetChild(0).gameObject;

        curScreen.width = Screen.width;
        curScreen.height = Screen.height;

        effect1.initial = new Vector3(Screen.width / 2, Screen.height - Screen.height / 8, 0);
        effect2.initial = new Vector3(Screen.width / 2, Screen.height / 8, 0);
        effect3.initial = new Vector3(Screen.width / 17, Screen.height / 2, 0);
        effect4.initial = new Vector3(Screen.width - Screen.width / 17, Screen.height / 2, 0);

        skillEffect1 = hurtObject.transform.GetChild(0).gameObject;
        skillEffect2 = hurtObject.transform.GetChild(1).gameObject;
        skillEffect3 = hurtObject.transform.GetChild(2).gameObject;
        skillEffect4 = hurtObject.transform.GetChild(3).gameObject;

        effect1.afterPosition = skillEffect1.transform.position + new Vector3(0, Screen.height / 2, 0);
        effect2.afterPosition = skillEffect2.transform.position + new Vector3(0, -Screen.height / 2, 0);
        effect3.afterPosition = skillEffect3.transform.position + new Vector3(-Screen.width / 2, 0, 0);
        effect4.afterPosition = skillEffect4.transform.position + new Vector3(Screen.width / 2, 0, 0);


        skillEffect1.transform.position = effect1.afterPosition;
        skillEffect2.transform.position = effect2.afterPosition;
        skillEffect3.transform.position = effect3.afterPosition;
        skillEffect4.transform.position = effect4.afterPosition;
    }
    private void Update()
    {

        if (Screen.width != curScreen.width || Screen.height != curScreen.height)
        {
            curScreen.width = Screen.width;
            curScreen.height = Screen.height;

            effect1.initial = new Vector3(Screen.width / 2, Screen.height - Screen.height / 8, 0);
            effect2.initial = new Vector3(Screen.width / 2, Screen.height / 8, 0);
            effect3.initial = new Vector3(Screen.width / 17, Screen.height / 2, 0);
            effect4.initial = new Vector3(Screen.width - Screen.width / 17, Screen.height / 2, 0);

            effect1.afterPosition = skillEffect1.transform.position + new Vector3(0, Screen.height / 2, 0);
            effect2.afterPosition = skillEffect2.transform.position + new Vector3(0, -Screen.height / 2, 0);
            effect3.afterPosition = skillEffect3.transform.position + new Vector3(-Screen.width / 2, 0, 0);
            effect4.afterPosition = skillEffect4.transform.position + new Vector3(Screen.width / 2, 0, 0);
        }
        if (playerHealth.IsHurt)
        {
            //skillUseObject.SetActive(true);
            skillEffect1.transform.position = Vector2.Lerp(skillEffect1.transform.position, effect1.initial, 0.1f);
            skillEffect2.transform.position = Vector2.Lerp(skillEffect2.transform.position, effect2.initial, 0.1f);
            skillEffect3.transform.position = Vector2.Lerp(skillEffect3.transform.position, effect3.initial, 0.1f);
            skillEffect4.transform.position = Vector2.Lerp(skillEffect4.transform.position, effect4.initial, 0.1f);
            curTime += Time.deltaTime;
            if(curTime>= hurtTime)
            {
                curTime = 0;
                playerHealth.IsHurt = false;
            }
        }
        else
        {
            skillEffect1.transform.position = Vector2.Lerp(skillEffect1.transform.position, effect1.afterPosition, 0.005f);
            skillEffect2.transform.position = Vector2.Lerp(skillEffect2.transform.position, effect2.afterPosition, 0.005f);
            skillEffect3.transform.position = Vector2.Lerp(skillEffect3.transform.position, effect3.afterPosition, 0.005f);
            skillEffect4.transform.position = Vector2.Lerp(skillEffect4.transform.position, effect4.afterPosition, 0.005f);

        }
    }

}
