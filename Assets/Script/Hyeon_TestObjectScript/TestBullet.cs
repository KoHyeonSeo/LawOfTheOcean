using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private float damage;
    //스킬을 사용하는 User가 누구인지 알 수 있는 프로퍼티
    public GameObject User { get; set; }
    //데미지 즉, Power가 어느 정도인지 알 수 있는 프로퍼티
    public float BulletDamage { get { return damage; } set { damage = value; } }
    void Update()
    {
        Vector3 dir = Vector3.forward;
        transform.position += dir * speed * Time.deltaTime;        
    }
    private void OnTriggerEnter(Collider other)
    {
        //부딪힌 것이 스킬 사용자가 아니고 생명체(Entity)라면
        if (other.gameObject != User && other.gameObject.layer == 7)
        {
            //Player라면 데미지 깎음
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerHealth>().Damage(damage);
            }
            //Enemy라면 데미지 깎음
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
            //총알 삭제
            Destroy(gameObject);
        }

    }
}
