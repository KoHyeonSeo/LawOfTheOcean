using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubble : MonoBehaviour
{
    float currentTime;
    public float createTime =5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= createTime)
        {
            GetComponent<ParticleSystem>().Play();
            currentTime = 0;
        }
    }
}
