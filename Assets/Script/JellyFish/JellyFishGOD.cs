using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishGOD : MonoBehaviour
{
    public GameObject jellyFishFactory;
    
    [SerializeField] float createTime = 3;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            GameObject jellyFish = Instantiate(jellyFishFactory);
            jellyFish.transform.position = transform.position;
            currentTime = 0;
           
        }
    }
}
