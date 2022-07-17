using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenSkill : MonoBehaviour
{
    [SerializeField] private GameObject orb;
    private GameObject UsedOrb;
    private bool first = true;
    private bool end = true;
    private void Update()
    {
        if (first)
        {
            if (GameManager.instance.IsStealUse)
            {
                if (GetComponent<EnemyHealth>().DeadCheck)
                {
                    if (!GameManager.instance.IsSkillMaxCountError)
                    {
                        UIManager.instance.IsOrbMoving = true;
                        UsedOrb = Instantiate(orb);
                        UsedOrb.transform.position = transform.position;
                        first = false;
                    }
                    else
                    {
                        GetComponent<EnemyHealth>().EnemyDestroy();
                        GameManager.instance.IsStealUse = false;

                    }
                }

            }
        }
        if (!first && !GameManager.instance.IsSkillMaxCountError && end)
        {
            if (UsedOrb.GetComponent<SkillOrb>().IsTouch)
            {
                Destroy(UsedOrb);
                GetComponent<EnemyHealth>().EnemyDestroy();
                GameManager.instance.IsStealUse = false;
                end = false;
            }
        }
    }
}
