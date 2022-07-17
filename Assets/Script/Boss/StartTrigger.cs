using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    GameObject boss;
    void Start()
    {
        boss = GameObject.Find("Boss");
     
    }

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name.Contains("Player"))
        {
          
            boss.GetComponent<Boss>().first = true;
        }
        if (other.gameObject.name.Contains("Boss"))
        {
            other.gameObject.GetComponent<Boss>().first = false;
        }
    
    }
}
