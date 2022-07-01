using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 마우스 포인터 위치, 총알 속도
public class Bullet : MonoBehaviour
{
    [Header("총알 속성")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float damage = 10;
    private GameObject player;
    private PlayerShooter playerShooter;
    private Vector3 dir;
    //총알을 마우스 포인터 방향으로 이동시킨다.
    private void Awake()
    {
        //필요속성: 입력값
        player = GameObject.Find("Player");
        playerShooter = player.GetComponent<PlayerShooter>();
    }
    private void Start()
    {
        //적을 맞췄으면 적 쪽으로 bullet이 향하게 하고 싶다.
        if (playerShooter.IsEnemyHit)
        {
            dir = playerShooter.EnemyPosition - transform.position;
            playerShooter.IsEnemyHit = false;
        }
        else
        {
            //아니면 그냥 가던길 가자.
            dir = playerShooter.BulletMaxDirection;
        }
        transform.rotation = Quaternion.LookRotation(dir).normalized;
    }
    void Update()
    {
        //총알을 이동시킨다.
        transform.position += dir.normalized * speed* Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        string colliderTag = other.gameObject.tag;
        //맞은 오브젝트가 player, platform,Deadzone이 아니라면,
        if (colliderTag != "Player" && colliderTag != "DeadZone" && colliderTag != "Platform")
        {
            //맞은 오브젝트가 enemy라면
            if (colliderTag == "Enemy")
            {
                //enemy에 Damage주기
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
                //자기 자신 사라지기
                Destroy(gameObject);
            }
            else
            {
                //아니면 상대도 죽고 나도 죽고
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        //맞은 오브젝트가 player, platform,Deadzone라면,
        else
        {
            //나만 죽기
            Destroy(gameObject);
        }
    }
    
}
