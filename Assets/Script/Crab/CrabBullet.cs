using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrabBullet : MonoBehaviour
{

    [SerializeField] private float speed;
    private float damage;
    private GameObject user;
    [SerializeField] private float heal = 10;
    //스킬을 사용하는 User가 누구인지 알 수 있는 프로퍼티
    public GameObject User { get { return user; } set { user = value; } }

    //데미지 즉, Power가 어느 정도인지 알 수 있는 프로퍼티
    [SerializeField] private float skillMaxDistance = 50;
    public Transform target;
    private PlayerInput playerInput;
    Vector3 dir;
    Vector3 cdir;
    public float BulletDamage { get { return damage; } set { damage = value; } }
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerInput = player.GetComponent<PlayerInput>();


        target = player.transform;
        if (User == player)
        {
            Vector3 mousepos = new Vector3(Screen.width / 2, Screen.height / 2);
            mousepos.z = skillMaxDistance;
            cdir = Camera.main.ScreenToWorldPoint(mousepos);
            dir = cdir - transform.position;
            dir.Normalize();
            Quaternion prot = Quaternion.LookRotation(dir.normalized);
            transform.rotation = prot;
        }
        else
        {
            dir = target.position - user.transform.position;
            dir.Normalize();
            Quaternion rot = Quaternion.LookRotation(dir.normalized);
            transform.rotation = rot;
            print(user);
        }
    }
    void Update()
    {
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
                user.gameObject.GetComponent<EnemyHealth>().Heal(10);
                print("닿았다" + damage);
            }
            //Enemy라면 데미지 깎음
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
                user.gameObject.GetComponent<PlayerHealth>().Heal(10);
            }
            //총알 삭제
            Destroy(gameObject);
        }

    }


}
