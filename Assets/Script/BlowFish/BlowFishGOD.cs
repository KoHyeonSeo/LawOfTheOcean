using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowFishGOD : MonoBehaviour
{
    public GameObject blowFishFactory;

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
                GameObject jellyFish = Instantiate(blowFishFactory);
                jellyFish.transform.position = transform.position + new Vector3(Random.value * 5, Random.value * 5, Random.value * 5);
                jellyFish.name = blowFishFactory.name + i;
                i++;
                currentTime = 0;

            }
        }
    }
}
