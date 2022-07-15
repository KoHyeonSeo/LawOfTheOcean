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

    private Animation animation;
    private EnemyDetection detection;
    private EnemyHealth health;
    private Vector3 dir;
    private State curState;
    private State preState;
    private float curTime = 0;
    private float hurtAnimTime = 1.15f;
    private float hurtCurTime = 0;
    private float attackAnimTime = 1.1f;
    private bool isAttacking = false;
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
        dir = Vector3.forward;
        animation.Play();
        skill.Power = damage;
    }
    private void Update()
    {
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
    private void FixedUpdate()
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
        //Debug.Log($"Attack: {isAttacking}");
        curTime += Time.deltaTime;
        if (!isAttacking)
        {
            isAttacking = true;
            skill.UseSkill();
        }
        if (curTime >= attackAnimTime)
        {
            curTime = 0;
            isAttacking = false;
            curState = State.FOLLOW;
        }
        if (health.isHurt)
        {
            curState = State.HURT;
            preState = State.ATTACK;
        }
    }
    private void Follow()
    {
        //print("Follow");
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
        }
        
    }
}