using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject start;
    public GameObject jellyFactory;
    Transform target;
    Vector3 dir;
    float speed = 5;

    float currentTime;
    float createTime = 20;
    float jellyTime = 2;
    bool jelly = false;
    void Start()
    {
        target = start.transform;
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);


    }




}
