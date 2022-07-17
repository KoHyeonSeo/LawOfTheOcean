using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishGOD : MonoBehaviour
{
    public GameObject jellyFishFactory;
    [SerializeField] float range = 30;

    [SerializeField] float createTime = 3;
    float currentTime;
    int maxCount = 10;
    int count;
    int i;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= maxCount)
        {
            currentTime += Time.deltaTime;
            if (currentTime > createTime)
            {
                GameObject jellyFish = Instantiate(jellyFishFactory);
                jellyFish.transform.position = transform.position + new Vector3(Random.value * range, Random.value * range, Random.value * range);
                jellyFish.name = jellyFishFactory.name + i;
                i++;
                currentTime = 0;

            }
        }
    }
}
