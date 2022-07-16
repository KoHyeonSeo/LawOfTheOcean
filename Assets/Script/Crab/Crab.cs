using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    // 게
    // 플레이어가 게의 감지범위에 들어오면
    // 빠르게 위로 뛰어오른뒤 천천히 감속한다.
    // 플레이어를 쫓아오며 공격한다.
    // 공격할때 플레이어의 hp를 달게하고
    // 본인의 hp를 회복한다.
    // 플레이어가 범위를 벗어나면
    // 다시 제자리로 돌아간다.

    // FSM으로 상태를 제어하고싶다.
    [SerializeField] private AnimationClip[] animations;
    [SerializeField] private Skill crab;
    [SerializeField] private float createTime = 1;
    [SerializeField] private float attackTime = 1;
    private new Animation animation;
    private EnemyHealth health;
    
    private State hurtState;
    GameObject target;
    
    Vector3 start;
    Vector3 dir;

    public enum State
    {
        Idle,
        Move,
        Attack,
        Return,
        Hurt,
        Die,
       
    }

    public State state;
    public bool hide = true;
    float firstDetect = 20;
    float detect = 10;
    float speed = 3;
    float attackDistance = 5;
    float currentTime;
    float turnSpeed = 5f;
    bool jump = true;
    private float hurtAnimTime = 1.12f;
   private float hurtCurTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        hurtState = State.Move;
        state = State.Idle;
        target = GameObject.Find("Player");
        health = GetComponent<EnemyHealth>();
        animation = GetComponent<Animation>();
          
        animation.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        if (state == State.Move)
        {
            StartCoroutine("IeMove");
        }
        if (state == State.Attack)
        {
            UpdateAttack();
        }
        if (state == State.Return)
        {
            UpdateReturn();
        }
        if (state == State.Hurt)
        {
            Hurt();
        }
        if (state == State.Die)
        {
            Die();
        }
        if (health.DeadCheck)
        {
            state = State.Die;
        }
    }

    private void UpdateIdle()
    {
        animation.clip = animations[0];
        animation.Play();
        start = transform.position;
        float distance = Vector3.Distance(target.transform.position, transform.position);

        bool isInSight = CheckPlayerAngle(target.transform.position);

        // 만약 플레이어와의 거리가 감지거리보다 작으면
        if (firstDetect > distance && isInSight)
        {
            //  Move상태로 전이한다.
            state = State.Move;
        }
        if (health.isHurt)
        {
            state = State.Hurt;
            hurtState = State.Move;
        }
    }
    bool CheckPlayerAngle(Vector3 position)
    {
        // 1. 체크하려는 대상을 바라보는 벡터를 구한다.
        Vector3 direction = position - transform.position;
        // 2. 나의 정면 벡터와 앞에서 구한 벡터를 서로 비교해서 사잇각을 구한다.
        float checkDegree = Vector3.Angle(transform.up, direction);

        // 3. 구해진 각도가 45도 이내라면 true, 45도 밖이면 false라고 반환한다.
        if (checkDegree <= 45)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void UpdateAttack()
    {
        animation.clip = animations[2];
        animation.Play();
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // 1. 시간이 흐르다가  
        currentTime += Time.deltaTime;
        // 2. 일정시간이 되면
        if (currentTime > createTime)
        {
            // 공격 애니메이션 시작
            animation.clip = animations[2];
            animation.Play();
            crab.User = gameObject;
            // 3. 공격을 한다.
            crab.UseSkill();
            // 4. 공격을 한뒤에는 시간을 초기화한다.
            currentTime = 0;
        }
        // 5. 타겟과의 거리가
        // 6. 만약 공격범위를 벗어나면
        if (distance > attackDistance)
        {

            // 7. Move상태로 전이한다.
            state = State.Move;
        }
        if (health.isHurt)
        {
            state = State.Hurt;
            hurtState = State.Attack;
        }
    }
    IEnumerator IeMove()
    {
        // start coroutine하는 시점
        if (jump)
        {
            // 1. 플레이어의 위치까지 올라오고싶다
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.transform.position.y, transform.position.z), 0.009f);
            // 2. 코루틴에서 한번만 실행하고 
            yield return new WaitForSeconds(1f);
            jump = false;
        }
        animation.clip = animations[1];
        animation.Play();
        // 3. 그 다음은 영원히 쫓아오는걸로
        dir = target.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;

        float distance = Vector3.Distance(target.transform.position, transform.position);
        // 거리가 공격거리보다 작으면
        if (attackDistance > distance)
        {
            //Attack 상태로 바뀐다.
            state = State.Attack;
        }
        if (distance > detect)
        {
            state = State.Return;
        }
    }
    private void UpdateReturn()
    {
        // 만일, 나의 현재위치가 start 위치에서 10센티미터 이상이라면..
        animation.clip = animations[1];
        animation.Play();
        Vector3 back = start - transform.position;
        if (back.magnitude > 0.1f)
        {
            // start 방향으로
            // 되돌아간다.
            transform.position += back.normalized * speed * Time.deltaTime;
        }
        // 그렇지 않다면, 나의 위치를 start으로 설정한다.       
        else
        {
            transform.position = start;
            state = State.Idle;
            jump = true;
        }
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // 만약 플레이어와의 거리가 감지거리보다 작으면
        if (detect > distance)
        {
            // Move상태로 전이한다.
            state = State.Move;
        }
    }
    private void Hurt()
    {
        animation.clip = animations[1];
        animation.Play();
        state = hurtState;
        hurtCurTime += Time.deltaTime;
        if (hurtCurTime >= hurtAnimTime)
        {
            state = hurtState;
            health.isHurt = false;
            hurtCurTime = 0;
        }
    }
    private void Die()
    {
        animation.clip = animations[4];
        animation.Play();
    }

  
}
