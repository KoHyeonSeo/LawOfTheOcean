using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jellyFactory;
    public GameObject blowFactory;
    public GameObject swordFactory;
    GameObject crab;
    float jellyCurrentTime;
    float blowCurrentTime;
    float swordCurrentTime;
    [SerializeField]   float summonTime = 2;
    EnemyHealth enemyHealth;
    
    void Start()
    {
        enemyHealth =GameObject.Find("Boss").GetComponent<EnemyHealth>();
        crab = GameObject.Find("Cube");
        crab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyHealth.Health <= enemyHealth.MaxHealth* 0.75)
        {
            jellyCurrentTime += Time.deltaTime;
            if (jellyCurrentTime > summonTime)
            { 
            GameObject jelly = Instantiate(jellyFactory);
            jelly.transform.position = transform.position;
                jellyCurrentTime = 0;
            }
        }

        if (enemyHealth.Health <= enemyHealth.MaxHealth * 0.5)
        {

            summonTime = 3;
            blowCurrentTime += Time.deltaTime;
            crab.SetActive(true);
            if (blowCurrentTime > summonTime)
            {
                GameObject blow = Instantiate(blowFactory);
                blow.transform.position = transform.position;
                blowCurrentTime = 0;
            }
        }
        if (enemyHealth.Health <= enemyHealth.MaxHealth * 0.25)
        {
            summonTime = 4;
            swordCurrentTime += Time.deltaTime;
            if (swordCurrentTime > summonTime)
            {
                GameObject sword = Instantiate(blowFactory);
                sword.transform.position = transform.position;
                swordCurrentTime = 0;
            }
        }
    }
}
