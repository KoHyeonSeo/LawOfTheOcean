using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject skillFactory;
    public void JellyFishAttack()
    {
        GameObject bullet = Instantiate(skillFactory);    
        bullet.transform.position = transform.position;       
    }
}
