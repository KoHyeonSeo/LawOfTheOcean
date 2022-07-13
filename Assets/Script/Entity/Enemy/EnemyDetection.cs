using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private float aggroRange = 10f;

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
                else
                {
                    Target = null;
                }
            }
        }
        else
        {
            Target = null;
        }
    }
    private void OnDrawGizmos()
    {
        Color gizmos = Gizmos.color;

        gizmos = Color.yellow;
        gizmos.a = 0.2f;
        Gizmos.DrawSphere(transform.position, aggroRange);
    }
}
