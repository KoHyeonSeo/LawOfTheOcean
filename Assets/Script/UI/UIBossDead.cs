using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBossDead : MonoBehaviour
{
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject fight;
    [SerializeField] private GameObject end;
    private float startTime = 1f;
    private float curTime = 0;
    private GameObject boss;
    private bool isStart = true;
    void Start()
    {
        start.SetActive(false);
        end.SetActive(false);
        fight.SetActive(false);
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            curTime += Time.deltaTime;
            if (curTime > startTime)
            {
                start.SetActive(true);
                isStart = false;
            }
        }
        else
        {
            if (boss.GetComponent<Boss>().first)
            {
                start.SetActive(false);
                fight.SetActive(true);
            }
            if (boss.GetComponent<EnemyHealth>().DeadCheck == true)
            {
                end.SetActive(true);
                fight.SetActive(false);
            }
        }
    }
}
