using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenSkill : MonoBehaviour
{
    [SerializeField] private GameObject skill;
    private GameObject UsedOrb;
    private bool first = true;
    private void Update()
    {
        if (GetComponent<EnemyHealth>().DeadCheck && first)
        {
            if (GameManager.instance.IsStealUse)
            {
                UIManager.instance.IsOrbMoving = true;
                UsedOrb = Instantiate(skill);
                UsedOrb.transform.position = transform.position;
                first = false;
            }
        }
        if (!first)
        {
            if (UsedOrb.GetComponent<SkillOrb>().IsTouch)
            {
                Destroy(UsedOrb);
                GetComponent<EnemyHealth>().EnemyDestroy();
            }
        }
    }
}
