using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float aggroRange = 30f;
    public float delayTime = 5f;
    private float curTime = 0;
    public GameObject Target { get; set; }
    private void Update()
    {

        Collider[] cols = Physics.OverlapSphere(transform.position, aggroRange);
        if(cols.Length > 0)
        {
            for(int i = 0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Player"))
                {
                    Target = cols[i].gameObject;

                }
            }
        }
        else
        {
            Target = null;
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Color gizmos = Gizmos.color;

    //    gizmos = Color.yellow;
    //    gizmos.a = 0.2f;
    //    Gizmos.DrawSphere(transform.position, aggroRange);
    //}
}
