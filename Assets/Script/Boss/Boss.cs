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
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
        }
        if (bossHealth.DeadCheck)
        {
            animation.clip = animations[2];
            animation.Play();
        }

    }




}
