using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Vector3 initialRotation;   
    [SerializeField] private float speed = 2;
    PlayerInput playerInput;
    public GameObject shoot;
    public GameObject normal;
    Rigidbody rigid;
    public Animator anim;
    public GameObject gun;
    float currentTime;
    float fireTime = 1;
    float cameraTime = 0.1f;
    bool fire = false;
    
    
   
    public float Speed
    {
        get { return speed; }
        set
        {
            speed = value;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Quaternion quaternion = Quaternion.identity;
        quaternion.eulerAngles = initialRotation;
        Camera.main.transform.position = normal.transform.position;
    }

    
    
    // Update is called once per frame
    void Update()
    {
        // 플레이어가 입력받는 방향으로 움직일때
        // 물의 저항값이 증가한다.
        float x = playerInput.XAxisDir;
        float z = playerInput.ZAxisDir;
        if (z > 0 && fire == false)
        {
            anim.SetBool("Move",true);
            anim.SetBool("Idle", false);           
        }
        else if(fire == false)
        {
            anim.SetBool("Idle",true);
            anim.SetBool("Move", false);
        }

        //print(fire);


        if (playerInput.IsShootingButton)
        {
            fire = true;
            anim.SetBool("Fire", true);
            anim.SetBool("Idle", false);
            anim.SetBool("Move", false);
            currentTime = 0;
        }
        
        if (fire == true)
        {
            gun.SetActive(true);
            Camera.main.transform.position = shoot.transform.position;
            currentTime += Time.deltaTime;
            if (currentTime >= fireTime)
            {
                anim.SetBool("Fire", false);
                currentTime = 0;
                fire = false;
            }
            
        }
        else
        {
            //currentTime += Time.deltaTime;
            //if (currentTime >= cameraTime)
            //{
                gun.SetActive(false);

                Camera.main.transform.position = normal.transform.position;
            //    currentTime = 0;
            //}
            
        }
        
       

        Vector3 dir = new Vector3(x, 0, z);
        Vector3 cdir = Camera.main.transform.TransformDirection(dir.normalized).normalized;
        
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(cdir * speed);
            
    }

}
