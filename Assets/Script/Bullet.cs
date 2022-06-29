using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 마우스 포인터 위치, 총알 속도
public class Bullet : MonoBehaviour
{
    [Header("총알 속성")]
    [SerializeField] private float speed = 10;
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
        if (playerShooter.IsEnemyHit)
        {
            dir = playerShooter.EnemyPosition - this.transform.position;
            dir.Normalize();
        }
        else
        {
            dir = playerShooter.BulletMaxDirection;
        }
    }
    void Update()
    {
        //총알을 이동시킨다.
        this.transform.position += dir * speed* Time.deltaTime;
    }
}
