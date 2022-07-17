using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopSkill : MonoBehaviour
{
    private bool once = false;
    public bool StopSkill { get; set; }
    private void Update()
    {
        if (StopSkill&&!once)
        {
            Debug.Log($"{gameObject} : Stop");
            once = true;
        }
    }
}
