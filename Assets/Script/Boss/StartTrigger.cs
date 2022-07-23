using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTrigger : MonoBehaviour
{
    GameObject boss;
    private bool isOnce = true;
    void Start()
    {
        boss = GameObject.Find("Boss");
     
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            if (boss.GetComponent<EnemyHealth>().DeadCheck == true)
            {
                SceneManager.LoadScene(6);
            }
            else if (isOnce)
            {
                boss.GetComponent<Boss>().first = true;
            }
        }
        if (other.gameObject.name.Contains("Boss") && isOnce)
        {
            other.gameObject.GetComponent<Boss>().first = false;
            other.gameObject.GetComponent<Boss>().isStart = true;
            isOnce = false;
        }

    }
}
