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
    public float HP
    {
        get
        { return HP; }
        set
        {
            hp = value;
            sliderHP.value = value;
        }
    }
       

    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            //gameObject.SetActive(false);
        }
        else
        {
        enemy = UIManager.instance.CurrentEnemy;
        EnemyHealth enemyHP = UIManager.instance.CurrentEnemy.GetComponent<EnemyHealth>();
            gameObject.SetActive(true);
            float hp = enemyHP.EnemyHealthProp;
            sliderHP.maxValue = maxHP;
            maxHP = enemyHP.EnemyHealthProp;
        }
        transform.position = new Vector3(0, 1, 0);
    }
}
