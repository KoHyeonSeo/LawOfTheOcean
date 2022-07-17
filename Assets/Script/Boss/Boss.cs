using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject start;
    EnemyHealth bossHealth;
    public bool first = false;
    Transform target;
    [SerializeField] private AnimationClip[] animations;
    private new Animation animation;
    private EnemySkill enemySkill;
    Transform player;
    Vector3 dir;
    EnemyStopSkill enemyStopSkill;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
        if (first == true)
        {
            animation.clip = animations[3];
            animation.Play();
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
        }
        if (!enemyStopSkill.StopSkill && !enemySkill.enabled && Vector3.Distance(transform.position, target.position) <= 18f)
        {
            enemySkill.enabled = true;
        }
        else if (enemyStopSkill.StopSkill)
        {
            enemySkill.enabled = false;
        }
        if (bossHealth.Health == bossHealth.MaxHealth * 0.75)
        {
            
            animation.clip = animations[0];
            animation.Play();
        }
        if (bossHealth.Health == bossHealth.MaxHealth * 0.5)
        {
            animation.clip = animations[0];
            animation.Play();
        }
        if (bossHealth.Health == bossHealth.MaxHealth * 0.25)
        {
            animation.clip = animations[0];
            animation.Play();
        }
        if (bossHealth.DeadCheck)
        {
            animation.clip = animations[2];
            animation.Play();
        }
       // print(first);
    }




}
