using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float currentTime;
    [SerializeField]
    private float createTime = 2;
    public GameObject bulletFactory;
    // Update is called once per frame
    void Update()
    {
       
    }
    public void JellyFishAttack()
    {
        // 시간이 흐르다가  
        currentTime += Time.deltaTime;
        // 일정시간이 되면
        if (currentTime > createTime)
        {
            // 총알공장에서 총알을 생성해
            GameObject bullet = Instantiate(bulletFactory);
            // 내 위치에 가져다 놓는다.
            bullet.transform.position = transform.position;
            // 3. 공격을 한뒤에는 시간을 초기화한다.
            currentTime = 0;
        }
    }
    
    

}
