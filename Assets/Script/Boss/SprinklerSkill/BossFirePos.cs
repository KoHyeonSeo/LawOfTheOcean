using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirePos : MonoBehaviour
{

    [SerializeField] private GameObject bulletFactory;
    [SerializeField] private int bulletCount = 50;
    [SerializeField] private float createTime = 0.5f;
    private float curTime = 0;
    private Vector3 dir;
    private int i = 0;
    public GameObject SkillUser { get; set; }
    public float SkillDamage { get; set; }
    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= createTime)
        {
            curTime = 0;
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(transform.up * 1000, ForceMode.Force);
            if (i >= bulletCount)
            {
                Destroy(gameObject);
            }
            else
            {
                i++;
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 100f, 0) * Time.deltaTime, Space.World);
    }
}
