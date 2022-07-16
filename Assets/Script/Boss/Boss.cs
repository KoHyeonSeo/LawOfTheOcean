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

    Transform player;
    Vector3 dir;
    
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
        start = GameObject.Find("Start");
        target = start.transform;
        animation = GetComponent<Animation>();
        first = false;
        bossHealth = GetComponent<EnemyHealth>();
        
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

    }




}
