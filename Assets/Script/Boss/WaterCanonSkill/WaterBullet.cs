using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public GameObject BulletUser { get; set; }
    public float BulletDamage { get; set; }
    private void OnTriggerEnter(Collider other)
    {
        //Player��� ������ ����
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().Damage(BulletDamage);
        }
        //�Ѿ� ����
        Destroy(gameObject);
    }
}
