using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    public Transform target;
    
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        target = player.transform;
        dir = target.position - transform.position;
        dir.Normalize();
        Quaternion rot = Quaternion.LookRotation(dir.normalized);
        transform.rotation = rot;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
