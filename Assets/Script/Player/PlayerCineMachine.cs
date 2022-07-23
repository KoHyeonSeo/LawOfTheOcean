using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCineMachine : MonoBehaviour
{
    float speed = 5;
    Vector3 dir;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        GameObject start = GameObject.Find("Cine");
        target = start.transform;
        dir = target.position - transform.position;
        dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 0)
        {
            speed -= Time.deltaTime;
        }
        transform.position += dir * speed * Time.deltaTime;
    }
}
