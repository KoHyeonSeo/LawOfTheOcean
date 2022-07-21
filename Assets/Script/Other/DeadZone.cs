using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private float hurtTime = 1.5f;
    private float curTime = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "DeadZone"&& collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("DeadZone") && !collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("맞음");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            curTime += Time.deltaTime;
            if (curTime >= hurtTime)
            {
                curTime = 0;   
                collision.gameObject.GetComponent<PlayerHealth>().Damage(5);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            curTime = 0;
        }
        else if(!collision.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("맞음");
            Destroy(collision.gameObject);
        }
    }
}
