using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCineMachine : MonoBehaviour
{
    float speed = 0;
    Vector3 dir;
    public Transform target;
    private new Animation animation;
    [SerializeField] private AnimationClip[] animations;
    float currentTime;
    float createTime = 20;
    // Start is called before the first frame update
    void Start()
    {
        
        animation = GetComponent<Animation>();
        animation.clip = animations[0];
        animation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime < createTime)
        {
            animation.clip = animations[1];
            animation.Play();
        }
        else
        {
            animation.clip = animations[0];
            animation.Play();
        }
        dir = target.position - transform.position + new Vector3(0,-5,0);
        dir.Normalize();
        speed += Time.deltaTime;
        
        transform.position += dir * speed * Time.deltaTime;
    }
}
