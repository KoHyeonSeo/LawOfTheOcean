using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCineMachine : MonoBehaviour
{
    float speed = 5;
    Vector3 dir;
    public Transform target;
    private new Animation animation;
    [SerializeField] private AnimationClip[] animations;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        target = player.transform;
        dir = target.position - transform.position;
        dir.Normalize();
        animation = GetComponent<Animation>();
        animation.clip = animations[0];
        animation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime;
        animation.clip = animations[0];
        animation.Play();
        transform.position += dir * speed * Time.deltaTime;
    }
}
