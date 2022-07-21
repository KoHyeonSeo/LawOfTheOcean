using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject start;
    EnemyHealth bossHealth;
    public bool first = false;
    Transform target;
    [SerializeField] private AnimationClip[] animations;
    [SerializeField] private GameObject IdleBubble;
    [SerializeField] private GameObject hurtBubble;
    [SerializeField] private GameObject deadBubble;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private float turnSpeed = 5f;
    public Vector3 position;
    private new Animation animation;
    private EnemySkill enemySkill;
    private float curHurtTime = 0;
    private float hurtTime = 2.5f;
    private float curDieTime = 0;
    private float DieTime = 2.5f;
    private bool isDie = false;
    private bool isHurt = false;
    private float moveTime = 2;
    private float curTime = 0;
    private float waitTime = 3;
    private float waitCurTime = 0;
    private bool isMoving = false;
    private bool isStartingMoving = false;
    public bool isStart = false;
    EnemyStopSkill enemyStopSkill;
    private Vector3 dir;
    private bool isMoving_Y = true;
    private GameObject player;


    [Header("sin 움직임 멤버변수")]
    [SerializeField] private float speed = 1;
    void Start()
    {
        player = GameObject.Find("Player");
        start = GameObject.Find("Start");
        target = start.transform;
        animation = GetComponent<Animation>();
        first = false;
        bossHealth = GetComponent<EnemyHealth>();
        enemySkill = GetComponent<EnemySkill>();
        enemySkill.enabled = false;
        enemyStopSkill = GetComponent<EnemyStopSkill>();
        animation.clip = animations[3];
        animation.Play();
        hurtBubble.SetActive(false);
        deadBubble.SetActive(false);
        enemySkill.enabled = false;

        float x = Random.Range(point1.position.x, point2.position.x);
        float y = Random.Range(point1.position.y, point2.position.y);
        float z = Random.Range(point1.position.z, point2.position.z);
        position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving_Y)
        {
            dir = player.transform.position - transform.position + new Vector3(0, -10, 0);
            Vector3 newDir2 = Vector3.RotateTowards(transform.forward, dir.normalized, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir2);
            Moving_Y();
        }
        if (isMoving)
        {
            isMoving_Y = false;
            MoveInArea();
        }
        if (isStartingMoving && !isMoving)
        {
            Wait();
        }
        if (first == true)
        {
            animation.clip = animations[3];
            animation.Play();
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
        }
        if (isStart && !first)
        {
            isStartingMoving = true;
            if (!enemyStopSkill.StopSkill && !enemySkill.enabled)
            {
                enemySkill.enabled = true;
            }
            else if (enemyStopSkill.StopSkill)
            {
                enemySkill.enabled = false;
            }
        }
        if (bossHealth.Health == bossHealth.MaxHealth * 0.75)
        {

            animation.clip = animations[0];
            animation.Play();
            hurtBubble.SetActive(true);
            isHurt = true;
            curHurtTime = 0;

        }
        if (bossHealth.Health == bossHealth.MaxHealth * 0.5)
        {
            animation.clip = animations[0];
            animation.Play();
            hurtBubble.SetActive(true);
            isHurt = true;
            curHurtTime = 0;
        }
        if (bossHealth.Health == bossHealth.MaxHealth * 0.25)
        {
            animation.clip = animations[0];
            animation.Play();
            hurtBubble.SetActive(true);
            isHurt = true;
            curHurtTime = 0;
        }
        if (bossHealth.DeadCheck)
        {
            animation.clip = animations[2];
            animation.Play();
            IdleBubble.SetActive(false);
            hurtBubble.SetActive(false);
            deadBubble.SetActive(true);
            enemySkill.enabled = false;
            if (!isDie)
            {
                Dead();
            }
        }
        if (isHurt)
        {
            Hurt();
        }
       // print(first);
    }
    private void Wait()
    {
        waitCurTime += Time.deltaTime;
        if(waitCurTime>= waitTime)
        {
            float ran = Random.Range(0.0f, 1.0f);
            //Debug.Log($"ran = {ran}");
            if (ran < 0.3f)
            {
                isMoving = true;
            }
            waitCurTime = 0;
        }
    }
    private void Dead()
    {
        curDieTime += Time.deltaTime;
        transform.position += Vector3.up * 10 * Time.deltaTime;
        if(curDieTime >= DieTime)
        {
            curDieTime = 0;
            isDie = true;
        }
        isMoving = false;
    }
    private void Hurt()
    {
        curHurtTime += Time.deltaTime;
        if (curHurtTime >= hurtTime)
        {
            curHurtTime = 0;
            isHurt = false;
            hurtBubble.SetActive(false);
        }
    }
    private void Moving_Y()
    {

        float y = speed * Mathf.Sin(Time.time);

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        if (y <= 0.001f && y >= -0.001f)
        {
            speed = Random.Range(0.5f, 3.1f);
        }
    }
    private void MoveInArea()
    {
        curTime += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, position, 0.005f);
        transform.LookAt(position);
        //dir = position - transform.position;
        //Vector3 newDir = Vector3.RotateTowards(transform.forward, dir.normalized, turnSpeed * Time.deltaTime, 0.0f);
        //transform.rotation = Quaternion.LookRotation(newDir);
        if (curTime >= moveTime)
        {
            float x = Random.Range(point1.position.x, point2.position.x);
            float y = Random.Range(point1.position.y, point2.position.y);
            float z = Random.Range(point1.position.z, point2.position.z);
            position = new Vector3(x, y, z);
            isMoving = false;
            isMoving_Y = true;
            curTime = 0;
        }
    }



}
