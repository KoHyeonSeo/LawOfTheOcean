using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        Vector3 dir = Vector3.forward;
        transform.position += dir * speed * Time.deltaTime;        
    }
}
