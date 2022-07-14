using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFish : MonoBehaviour
{

    [SerializeField] private AnimationClip[] animations;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private SwordFishSkill skill;
    [SerializeField] private float attackRange = 8f;
    private float damage = 20;
    
    private bool isWait = false;
    private float attackCurTime = 0;
    private float waitTime = 1f;

    private Animation animation;
    private EnemyDetection detection;
    private EnemyHealth health;
    private Rigidbody rigid;
    private Vector3 dir;
    private State curState;
    private State preState;
    private float curTime = 0;
    private float hurtAnimTime = 1.15f;
    private float hurtCurTime = 0;
    private bool isAttacking = false;
    private bool isOnce = false;
    public float SpeedChange { get { return speed; } set { speed = value; } }
    enum State
    {
        MOVE,
        FOLLOW,
        ATTACK,
        HURT,
        DIE
    }
    private void Start()
    {
        SpeedChange = speed;
        skill.User = gameObject;
        curState = State.MOVE;
        preState = State.MOVE;
        detection = GetComponent<EnemyDetection>();
        health = GetComponent<EnemyHealth>();
        animation = GetComponent<Animation>();
        rigid = GetComponent<Rigidbody>();
        dir = Vector3.forward;
        animation.Play();
        skill.Power = damage;
    }
    private void Update()
    {
        if (curState == State.MOVE)
        {
            Move();
        }
        if (curState == State.FOLLOW)
        {
            Follow();
        }
        if (curState == State.ATTACK)
        {
            Attack();
        }
        if (curState == State.HURT)
        {
            Hurt();
        }
        if (curState == State.DIE)
        {
            Die();
        }
        if (health.DeadCheck)
            curState = State.DIE;
    }
    private void Move()
    {
        //Move 애니메이션 실행
        animation.clip = animations[0];
        animation.Play();
        if (detection.Target)
        {
            curState = State.FOLLOW;
        }
        else
        {
            //Debug.Log("Move 상태");
            dir = Vector3.forward;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position += dir.normalized * speed * Time.deltaTime;
        }
        if (health.isHurt)
        {
            curState = State.HURT;
            preState = State.MOVE;
        }
    }
    private void Attack()
    {

        animation.clip = animations[2];
        animation.Play();
        //Debug.Log("Attack 상태");
        if (!detection.Target)
        {
            curState = State.MOVE;
        }
        else
        {
            if (!isWait)
            {
                isAttacking = true;
                curTime += Time.deltaTime;
                if (curTime >= skill.CoolTime)
                {
                    skill.UseSkill();
                    curTime = 0;
                    isAttacking = false;
                }
                dir = detection.Target.transform.position - transform.position - new Vector3(0, 2f, 0);
                Vector3 newDir = Vector3.RotateTowards(transform.forward, dir.normalized, turnSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir.normalized);
                float dist = Vector3.Distance(detection.Target.transform.position, transform.position);
                if (dist >= 8f)
                {
                    transform.position += dir.normalized * speed * Time.deltaTime;
                }
                else if (dist > attackRange)
                {
                    curState = State.FOLLOW;
                }
            }
            else if( isWait && !isAttacking)
            {
                attackCurTime += Time.deltaTime;
                if (attackCurTime >= waitTime)
                {
                    isWait = false;
                    attackCurTime = 0;
                }
            }
        }
        if (health.isHurt)
        {
            curState = State.HURT;
            preState = State.ATTACK;
        }
    }
    private void Follow()
    {
        //Move 애니메이션 실행
        animation.clip = animations[0];
        animation.Play();
        if (!detection.Target)
        {
            curState = State.MOVE;
        }
        else
        {
            //Debug.Log("Follow 상태");
            dir = detection.Target.transform.position - transform.position - new Vector3(0, 2f, 0);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir.normalized, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir.normalized);
            transform.position += dir.normalized * speed * Time.deltaTime;

            float dist = Vector3.Distance(detection.Target.transform.position, transform.position);
            if (dist <= attackRange)
            {
                curState = State.ATTACK;
            }
        }
        if (health.isHurt)
        {
            curState = State.HURT;
            preState = State.FOLLOW;
        }
    }
    private void Hurt()
    {
        //Debug.Log("Hurt 상태");
        //다치는 애니메이션 실행
        animation.clip = animations[1];
        animation.Play();
        
        hurtCurTime += Time.deltaTime;
        if (hurtCurTime >= hurtAnimTime)
        {
            curState = preState;
            health.isHurt = false;
            hurtCurTime = 0;
        }

    }
    private void Die()
    {
        animation.clip = animations[3];
        animation.Play();
        //죽은 애니메이션 실행
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Damage(damage);
            if (!isAttacking)
            {
                isWait = true;
            }
        }
        
    }
}