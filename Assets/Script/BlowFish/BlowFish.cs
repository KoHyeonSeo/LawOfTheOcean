using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowFish : MonoBehaviour
{
    [SerializeField] private AnimationClip[] animations;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private Skill skill;
    [SerializeField] private float attackRange = 8f;

    private Animation animation;
    private EnemyDetection detection;
    private EnemyHealth health;
    private Vector3 dir;
    private State curState;
    private State preState;
    private float curTime = 0;
    private float hurtAnimTime = 1.12f;
    private float hurtCurTime = 0;
    private EnemyStopSkill enemyStopSkill;

    enum State
    {
        MOVE,
        FOLLOW,
        ATTACK,
        HURT,
        DIE
    }
    
    //To do 
    //애니메이션 넣기


    private void Start()
    {
        skill.User = gameObject;
        curState = State.MOVE;
        preState = State.MOVE;
        detection = GetComponent<EnemyDetection>();
        health = GetComponent<EnemyHealth>();
        animation = GetComponent<Animation>();
        dir = Vector3.forward;
        animation.Play();
        enemyStopSkill = GetComponent<EnemyStopSkill>();
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
        if(curState == State.DIE)
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
        //부풀리는 애니메이션 실행
        animation.clip = animations[2];
        animation.Play();
        //Debug.Log("Attack 상태");
        //Debug.Log($"{enemyStopSkill.StopSkill}");
        curTime += Time.deltaTime;
        if (curTime >= skill.CoolTime)
        {
            if (!enemyStopSkill.StopSkill)
            {
                skill.User = gameObject;
                skill.UseSkill();
            }
            curTime = 0;
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
        //Move 애니메이션 실행
        animation.clip = animations[0];
        animation.Play();
        if (!detection.Target)
        {
            curState = State.MOVE;
        }
        else
        {
           // Debug.Log("Follow 상태");
            dir = detection.Target.transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
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
}
