using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    // 게
    // 플레이어가 게의 감지범위에 들어오면
    // 빠르게 위로 뛰어오른뒤 천천히 감속하고

    // 플레이어를 쫓아오며 공격한다.
    // 공격할때 플레이어의 hp를 달게하고
    // 본인의 hp를 회복한다.
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
    
    State state;

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
        if ( state == State.Idle)
        {
            UpdateIdle();
        }
        else if( state == State.Move)
        {
            
            StartCoroutine("IeMove");
        }
        else if( state == State.Attack)
        {
            UpdateAttack();
        }
        else if( state == State.Return)
        {

        }
    }
    float detect = 10;
    Vector3 start;
    private void UpdateIdle()
    {
        start = transform.position;
        float distance = Vector3.Distance(target.transform.position, transform.position);

            // 만약 플레이어와의 거리가 감지거리보다 작으면
        if ( detect > distance)
        {
            state = State.Move;
        }
         // Move상태로 전이한다.
    }
    float speed = 3;
    float attackDistance = 1;
    //private void UpdateMove()
    //{
    //    // 타겟의 방향으로
    //    Vector3 dir = target.transform.position - transform.position;
    //    dir.Normalize();
    //    // 계속 이동한다.
    //    //transform.position += dir * speed * Time.deltaTime;
    //    transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x,target.transform.position.y,transform.position.z) , 0.05f);
    //    float distance = Vector3.Distance(target.transform.position, transform.position);
    //    // 만약 타겟과의 거리가 공격범위보다 작으면

    //    if (attackDistance > distance)
    //    {
    //    // Attack 상태로 바뀐다.
    //        state = State.Attack;
    //    }
    //}

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
        if(distance > attackDistance)
            {
                state = State.Move;
        // 6. Move상태로 전이한다.
            }
        }
    }
    bool sta = true;
    Vector3 back;
    IEnumerator IeMove()
    {

        // start coroutine하는 시점
        if (sta) {
        // 1. 플레이어의 위치까지 올라오고싶다
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.transform.position.y, transform.position.z), 0.009f);
        // 2. 코루틴에서 한번만 실행하고 
            yield return new WaitForSeconds(1f);
            sta = false;
        }
        // 3. 그 다음은 영원히 쫓아오는걸로
        Vector3 dir = target.transform.position - transform.position;
        Vector3 back = start - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
     
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (attackDistance > distance)
        {
            // Attack 상태로 바뀐다.
            state = State.Attack;
        }
        if (distance > detect)
        {
            state = State.Return;
        }
        
            
           
            //if (transform.position == start)
            //{
            //    state = State.Idle;
               
            //}
        
        //else if (distance < detect)
        //{
        //    transform.position += dir * speed * Time.deltaTime;
        //}

    }
    private void UpdateReturn()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
            transform.position += back * speed * Time.deltaTime;
        if (transform.position == start)
        {
            state = State.Idle;

        }
    }


}
