using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndingPlayerMove : MonoBehaviour
{
    private PlayableDirector pd;
    private Animator anim;
    void Start()
    {
        pd = GameObject.Find("Director").GetComponent<PlayableDirector>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pd.time >= 35f)
        {
            UpdateSwim();
        }
    }

    void UpdateSwim()
    {
        anim.SetBool("Fire", false);
        anim.SetBool("Move", true);
        anim.SetBool("Idle", false);
    }
}
