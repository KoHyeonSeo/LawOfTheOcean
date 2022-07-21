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
    private new Animation animation;
    private EnemySkill enemySkill;
    private float curHurtTime = 0;
    private float hurtTime = 2.5f;
    private float curDieTime = 0;
    private float DieTime = 2.5f;
    private bool isDie = false;
    private bool isHurt = false;
    private float turnTime = 2;
    private float curTime = 0;
    Transform player;
    private bool isMoving = false;
    private bool isStartingMoving = false;
    Vector3 dir;
    EnemyStopSkill enemyStopSkill;

    [Header("sin 움직임 멤버변수")]
    [SerializeField] private float speed = 1;

    
    void Start()
    {
        player = GameObject.Find("Player").transform;
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
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (isMoving)
        {
            Moving();
        }
        else if(isStartingMoving)
        {
            if (Vector3.Distance(transform.position, start.transform.position - Vector3.back * 20f) <= 40)
            {
                float ran = Random.Range(0.0f, 1.0f);
                if (ran < 0.01f)
                {
                    isMoving = true;
                    Debug.Log("시작");
                }
            }
            transform.position = Vector3.Lerp(transform.position, start.transform.position - Vector3.forward * 20f, Time.deltaTime);
        }
        if (first == true)
        {
            animation.clip = animations[3];
            animation.Play();
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
        }
        if (!enemyStopSkill.StopSkill && !enemySkill.enabled && Vector3.Distance(transform.position, target.position) <= 18f)
        {
            enemySkill.enabled = true;
            isStartingMoving = true;
        }
        else if (enemyStopSkill.StopSkill)
        {
            enemySkill.enabled = false;
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
    private void Dead()
    {
        curDieTime += Time.deltaTime;
        transform.position += Vector3.up * 10 * Time.deltaTime;
        if(curDieTime >= DieTime)
        {
            curDieTime = 0;
            isDie = true;
        }
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
    private void Move()
    {
        float y = speed * Mathf.Sin(Time.time);
        //Debug.Log($"y = {y} speed = {speed}");

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        if (y <= 0.001f && y >= -0.001f)
        {
            speed = Random.Range(0.5f, 3.1f);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, start.transform.position.y, transform.position.z), Time.deltaTime);
        }

    }
    private void Moving()
    {
        Debug.Log($"curTime = {curTime}");
        curTime += Time.deltaTime;
        if (curTime >= turnTime)
        {
            curTime = 0;
            isMoving = false;
        }
        transform.position += transform.forward * 5 * Time.deltaTime;
    }



}
