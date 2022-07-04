using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="EnemySkill/JellyFishSkill")]
public class JellyFishSkill : Skill
{
    public float speed = 5;
    public Transform target;
    public Transform jelly;
    Vector3 dir;

    public override void UseSkill()
    {
        GameObject player = GameObject.Find("Player");
        target = player.transform;
        dir = target.position - jelly.position;
        dir.Normalize();
        Quaternion rot = Quaternion.LookRotation(dir.normalized);
        jelly.rotation = rot;
    }

    // Update is called once per frame
    void Update()
    {
        jelly.position += dir * speed * Time.deltaTime;
    }
}
