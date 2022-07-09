using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    [SerializeField] private Skill jellyFish;
    /// <summary>
    /// 해파리
    /// 플레이어가 해파리의 감지범위에 들어오면
    /// 플레이어에게 일정 다가온뒤
    /// 플레이어를 쫓아오며 원거리 공격을한다.
    /// 공격할때 플레이어의 hp를 달게하고
    /// 경직효과를 준다.
    /// 플레이어가 범위를 벗어나면
    /// 다시 제자리로 돌아간다.
    /// </summary>

    // FSM으로 상태를 제어하고싶다.
    public enum State
    {
        Idle,
        Move,
        Attack,
        Return
    }

    public State state;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;

        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Move)
        {
            UpdateMove();
        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }
    }
    public float detect = 15;
    private void UpdateIdle()
    {
        Vector3 dir = Vector3.forward;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        float distance = Vector3.Distance(target.transform.position, transform.position);

        // 만약 플레이어와의 거리가 감지거리보다 작으면
        if (detect > distance)
        {
            state = State.Move;
        }
        // Move상태로 전이한다.
    }

    public float speed = 3;
    public float attackDistance = 5;
    public bool stopSkill = false;
    float currentTime;
    [SerializeField] private float createTime = 2;
    private void UpdateAttack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        // 1. 시간이 흐르다가  
        currentTime += Time.deltaTime;
        // 2. 일정시간이 되면
        if (currentTime > createTime)
        {
            jellyFish.User = gameObject;
            if (stopSkill == false) // false일때만 스킬 사용가능
            {
            jellyFish.UseSkill();
                print("발사");
            }
            currentTime = 0;
        }
        // 4. 타겟과의 거리가
        // 5. 만약 공격범위를 벗어나면
        if (distance > attackDistance)
        {
            // 6. Move상태로 전이한다.
            state = State.Move;
        }
    }
    float moveCreateTime = 1f;
    bool move = true;
    float sm;
    float jellySpeed = 2.2f;
    private void UpdateMove()
    {
        // 1. 플레이어게 향하는 방향으로
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        sm += speed * Time.deltaTime;
        // 2. 만약 move 가 true 이면
        if (move == true)
        {
            transform.position += dir * speed * Time.deltaTime;
            speed -= Time.deltaTime * jellySpeed;
            // sm이가 2가 될때 까지 움직인다.
            if (sm > 2)
            {
                move = false;
            }
        }
        if (move == false)
        {
            speed = 3;
            sm = 0;
            currentTime += Time.deltaTime;
            if (currentTime > moveCreateTime)
            {
                currentTime = 0;
                move = true;
            }
        }
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (attackDistance > distance)
        {
            // Attack 상태로 바뀐다.
            state = State.Attack;
        }
        if (detect < distance)
        {
            state = State.Idle;
        }
    }
}