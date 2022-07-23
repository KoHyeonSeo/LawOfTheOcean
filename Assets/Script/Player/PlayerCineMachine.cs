using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCineMachine : MonoBehaviour
{
    float speed = 2;
    Vector3 dir;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        GameObject start = GameObject.Find("Start");
        target = start.transform;
        dir = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
