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
    [SerializeField] private float skillMaxDistance = 950;
    public Transform target;
    private PlayerInput playerInput;
    Vector3 dir;
    Vector3 cdir;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerInput = player.GetComponent<PlayerInput>();
        
        
        target = player.transform;
        if (User == player)
        {
            Vector3 mousepos = playerInput.MousePosition;
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
        }
    }  
    bool playerStop = false;
    bool enemyStop = false;
    JellyFish jellyFish;
    float playerCurrentTime;
    float enemyCurrentTime;
    [SerializeField] private float stopTime = 3;
    // Update is called once per frame
    void Update()
    {        
        if (playerStop == true)
        {
            playerCurrentTime += Time.deltaTime;
            if (playerCurrentTime > stopTime)
            {
                GameManager.instance.IsStopAttack = false;
                
               
                playerCurrentTime = 0;
                playerStop = false;
            }
        }
        if (enemyStop == true)
        {
            enemyCurrentTime += Time.deltaTime;
            if (enemyCurrentTime > stopTime)
            {
                jellyFish.stopSkill = false;
                enemyCurrentTime = 0;
            }
        }
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        //부딪힌 것이 스킬 사용자가 아니고 생명체(Entity)라면
        if (other.gameObject != user && other.gameObject.layer == 7)
        {
        jellyFish = user.GetComponent<JellyFish>();
            //Player라면 데미지 깎음
            //발사를 일정시간동안 못함
            if (other.gameObject.CompareTag("Player"))
            {
                playerStop = true;
                other.gameObject.GetComponent<PlayerHealth>().Damage(damage);
                GameManager.instance.IsStopAttack = true;
            }
            //Enemy라면 데미지 깎음
            else
            {
                jellyFish = other.GetComponent<JellyFish>();
                print("맞음");
                enemyStop = true;
                jellyFish.stopSkill = true;
                
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
               
            }
            //총알 삭제         
        }
    }

}
