using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public GameObject BulletUser { get; set; }
    public float BulletDamage { get; set; }
    private void OnTriggerEnter(Collider other)
    {
        //부딪힌 것이 스킬 사용자가 아니고 생명체(Entity)라면
        if (other.gameObject != BulletUser && other.gameObject.layer == 7)
        {
            //Player라면 데미지 깎음
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerHealth>().Damage(BulletDamage);
            }
            //Enemy라면 데미지 깎음
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(BulletDamage);
            }
            //총알 삭제
            Destroy(gameObject);
        }
    }
}
