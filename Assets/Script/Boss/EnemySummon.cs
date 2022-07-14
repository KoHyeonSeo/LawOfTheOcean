using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyFactory;
    float currentTime;
    float createTime = 2;
    EnemyHealth enemyHealth;
    float stage = 0.9f;
    void Start()
    {
        enemyHealth =GameObject.Find("Boss").GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyHealth.Health <= enemyHealth.MaxHealth* stage)
        {
            currentTime += createTime;
            if (currentTime > createTime)
            { 
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            }
        }
    }
}
