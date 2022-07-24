using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jellyFactory;
    public GameObject blowFactory;
    public GameObject swordFactory;
    public GameObject crab;
    float jellyCurrentTime;
    float blowCurrentTime;
    float swordCurrentTime;
    int i;
    public float range = 5;
    [SerializeField]   float summonTime = 2;
    EnemyHealth enemyHealth;

    public GameObject User { get; set; }
    //데미지 즉, Power가 어느 정도인지 알 수 있는 프로퍼티
    void Start()
    {
        enemyHealth =GameObject.Find("Boss").GetComponent<EnemyHealth>();
        
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
            jelly.transform.position = transform.position + new Vector3(Random.value * range, Random.value * range, Random.value * range); 
                jelly.name = jellyFactory.name + "a" + i;
                i++;
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
                blow.transform.position = transform.position + new Vector3(Random.value * range, Random.value * range, Random.value * range); 
                blow.name = blowFactory.name + "a" + i;
                i++;
                blowCurrentTime = 0;
            }
        }
        if (enemyHealth.Health <= enemyHealth.MaxHealth * 0.25)
        {
            summonTime = 4;
            swordCurrentTime += Time.deltaTime;
            if (swordCurrentTime > summonTime)
            {
                GameObject sword = Instantiate(swordFactory);
                sword.transform.position = transform.position + new Vector3(Random.value * range, Random.value * range, Random.value * range); 
                sword.name = swordFactory.name + "a" + i;
                i++;
                swordCurrentTime = 0;
            }
        }
    }
}
