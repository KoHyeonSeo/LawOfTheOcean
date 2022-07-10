using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHP : MonoBehaviour
{
    [SerializeField] Slider sliderHP;
    float hp;
    public float maxHP;
    GameObject enemy;
    EnemyHealth enemyHP;
    

    // Start is called before the first frame update
    void Start()
    {
        enemy = UIManager.instance.CurrentEnemy;
        if (enemy == null)
        {
            print("비활성");
            gameObject.SetActive(false);
        }
        else
        {
            print("활성");
            enemyHP = enemy.GetComponent<EnemyHealth>();
            maxHP = enemyHP.EnemyHealthProp;
            sliderHP.maxValue = maxHP;
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            enemy = UIManager.instance.CurrentEnemy;
            enemyHP = enemy.GetComponent<EnemyHealth>();
            hp = enemyHP.Health;
            sliderHP.value = hp;
            gameObject.SetActive(true);
            print(sliderHP.value);
        }
        print(enemy);
    }
    
}
