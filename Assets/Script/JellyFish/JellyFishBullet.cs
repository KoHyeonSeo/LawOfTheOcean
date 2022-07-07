using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private GameObject user;
    private float damage;
    //스킬을 사용하는 User가 누구인지 알 수 있는 프로퍼티
    public GameObject User { get { return user; } set { user = value; } }
    //데미지 즉, Power가 어느 정도인지 알 수 있는 프로퍼티
    public float BulletDamage { get { return damage; } set { damage = value; } }

    public Transform target;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        target = player.transform;
        dir = target.position - user.transform.position;
        dir.Normalize();
        Quaternion rot = Quaternion.LookRotation(dir.normalized);
        transform.rotation = rot;

    }
    bool stop = false;
    float currentTime;
    [SerializeField] private float stopTime = 1;
    // Update is called once per frame
    void Update()
    {
        if (stop == true)
        {
            currentTime += Time.deltaTime;
            if (currentTime > stopTime)
            {
                //print("끝");
                currentTime = 0;
                GameManager.instance.IsStopAttack = false;
                Destroy(gameObject);
            }
        }

        //print(currentTime);
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {

        //부딪힌 것이 스킬 사용자가 아니고 생명체(Entity)라면
        if (other.gameObject != user && other.gameObject.layer == 7)
        {

          
            //Player라면 데미지 깎음
            //발사를 일정시간동안 못함
            if (other.gameObject.CompareTag("Player"))
            {
                //print("시작");
                stop = true;
                other.gameObject.GetComponent<PlayerHealth>().Damage(damage);

                GameManager.instance.IsStopAttack = true;

            }

            //Enemy라면 데미지 깎음
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
            //총알 삭제
           
        }
    }

}
