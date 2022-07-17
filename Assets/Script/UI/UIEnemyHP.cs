using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEnemyHP : MonoBehaviour
{
    [SerializeField] GameObject sliderHP;
    [SerializeField] GameObject textSilence;
    float hp;
    public float maxHP;
    GameObject enemy;
    EnemyHealth enemyHP;
    bool start = true;


    // Start is called before the first frame update
    void Start()
    {
        textSilence = transform.GetChild(1).gameObject;
        textSilence.SetActive(false);
        enemy = UIManager.instance.CurrentEnemy;
        if (enemy == null || enemy.name != gameObject.transform.parent.name)
        {
            //print("비활성");
            sliderHP.SetActive(false);
        }
        else
        {
            start = false;
            //print("활성");
            enemyHP = enemy.GetComponent<EnemyHealth>();
            maxHP = enemyHP.Health;
            sliderHP.GetComponent<Slider>().maxValue = maxHP;
            sliderHP.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemy = UIManager.instance.CurrentEnemy;
        if (enemy == null || enemy.name != gameObject.transform.parent.name)
        {
            sliderHP.SetActive(false);
            textSilence.SetActive(false);
        }
        else
        {
            //Debug.Log($"{gameObject} : {enemy.GetComponent<EnemyStopSkill>().StopSkill}");
            if (enemy.GetComponent<EnemyStopSkill>().StopSkill)
            {
                textSilence.SetActive(true);
            }
            else
            {
                textSilence.SetActive(false);
            }

            if (start)
            {
                enemyHP = enemy.GetComponent<EnemyHealth>();
                maxHP = enemyHP.Health;
                sliderHP.GetComponent<Slider>().maxValue = maxHP;
                start = false;
            }

            enemyHP = enemy.GetComponent<EnemyHealth>();
            hp = enemyHP.Health;
            sliderHP.GetComponent<Slider>().value = hp;
            sliderHP.SetActive(true);
            //print(sliderHP.GetComponent<Slider>().value);
        }
        //print(enemy);
    }
    
}
