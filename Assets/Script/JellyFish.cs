using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    // 해파리
    // 플레이어가 해파리의 감지범위에 들어오면
    // 플레이어에게 일정 다가온뒤

    // 플레이어를 쫓아오며 원거리 공격을한다.
    // 공격할때 플레이어의 hp를 달게하고
    // 경직효과를 준다
    // 플레이어가 범위를 벗어나면
    // 다시 제자리로 돌아간다.

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
        else if (state == State.Return)
        {
            UpdateReturn();
        }
    }
    public float detect = 15;
    Vector3 start;
    private void UpdateIdle()
    {
        start = transform.position;
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

   

    float currentTime;
    [SerializeField] private float createTime = 2;
    private void UpdateAttack()
    {
        // 1. 시간이 흐르다가  
        currentTime += Time.deltaTime;
        // 2. 일정시간외되면
        if (currentTime > createTime)
        {
            // 2. 공격을 한다.

            // 3. 공격을 한뒤에는 시간을 초기화한다.
            currentTime = 0;
            // 4. 타겟과의 거리가
            float distance = Vector3.Distance(target.transform.position, transform.position);
            // 5. 만약 공격범위를 벗어나면
            if (distance > attackDistance)
            {
                // 6. Move상태로 전이한다.
                state = State.Move;
            }
        }
    }
    private void UpdateMove()
    {
        
        // 1. 플레이어게 향하는 방향으로 일정거리 다가오고
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        // 2. 플레이어에게 닿을때 반복한다.
        transform.position += dir * speed * Time.deltaTime;
        
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (attackDistance > distance)
        {
            // Attack 상태로 바뀐다.
            state = State.Attack;
        }
        if (detect < distance)
        {
            state = State.Return;
        }
    }
    private void UpdateReturn()
    {
        // 만일, 나의 현재위치가 start 위치에서 10센티미터 이상이라면..

        Vector3 back = start - transform.position;
        if(back.magnitude > 0.1f)
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
            

        }
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // 만약 플레이어와의 거리가 감지거리보다 작으면
        if (detect > distance)
        {
        // Move상태로 전이한다.
            state = State.Move;
        }

    }
}