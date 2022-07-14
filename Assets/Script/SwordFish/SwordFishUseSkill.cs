using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFishUseSkill : MonoBehaviour
{
    [SerializeField] private float speedUpTime;
    [SerializeField] private float speedChange = 6f;
    private bool isSpeedUp = false;
    private float curTime = 0;
    public bool UseSkill { get; set; }
    public GameObject SkillUser { get; set; }
    public float SkillCoolTime { get; set; }
    private void Start()
    {
        speedUpTime = SkillCoolTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (UseSkill)
        {
            if (!isSpeedUp)
            {
                if (SkillUser.CompareTag("Enemy"))
                {
                    SkillUser.GetComponent<SwordFish>().SpeedChange += speedChange;
                }
                else
                {
                    SkillUser.GetComponent<PlayerMove>().Speed += speedChange;
                }
                isSpeedUp = true;
            }
            curTime += Time.deltaTime;
            if (curTime >= speedUpTime)
            {
                isSpeedUp = false;
                UseSkill = false;
                curTime = 0;
                if (SkillUser.CompareTag("Enemy"))
                {
                    SkillUser.GetComponent<SwordFish>().SpeedChange -= speedChange;
                }
                else
                {
                    SkillUser.GetComponent<PlayerMove>().Speed -= speedChange;
                }
                Destroy(gameObject);
            }
        }
    }
}
