using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowFishGOD : MonoBehaviour
{
    public GameObject blowFishFactory;
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
                GameObject blowFish = Instantiate(blowFishFactory);
                blowFish.transform.position = transform.position + new Vector3(Random.value * range, Random.value * range, Random.value * range);
                blowFish.name = blowFishFactory.name + i;
                i++;
                currentTime = 0;

            }
        }
    }
}
