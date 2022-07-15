using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name.Contains("Player"))
        {
            other.gameObject.GetComponent<Boss>().first = true;
        }
        //if (other. gameObject.name.Contains("Boss"))
        //{
        //    other.gameObject.GetComponent<Boss>().first = false;
        //}
    }
}
