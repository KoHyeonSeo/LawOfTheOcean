using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "DeadZone"&& collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(5);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "DeadZone" && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(5);
        }
    }
}
