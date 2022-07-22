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
    public GameObject swim;
    Rigidbody rigid;
    public Animator anim;
    public GameObject gun;
    float currentTime;
    float fireTime = 1;
    float cameraTime = 0.1f;
    bool fire = false;
    bool idle = false;
    bool move = false;
    float x;
    float z;

    public enum State
    {
        Idle,
        Swim,
        Shoot
    }

    public State state;
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
        Camera.main.transform.rotation = normal.transform.rotation;
    }



    // Update is called once per frame
    void Update()
    {
        //// 플레이어가 입력받는 방향으로 움직일때
        //// 물의 저항값이 증가한다.
        x = playerInput.XAxisDir;
        z = playerInput.ZAxisDir;
        //if (z > 0 && fire == false)
        //{
        //    anim.SetBool("Move",true);
        //    anim.SetBool("Idle", false);
        // Camera.main.transform.position = swim.transform.position;
        // Camera.main.transform.rotation = swim.transform.rotation;
        //}
        //else if(fire == false)
        //{
        //    anim.SetBool("Idle",true);
        //    anim.SetBool("Move", false);
        //}

        //print(fire);


        //if (playerInput.IsShootingButton)
        //{
        //    fire = true;
        //    anim.SetBool("Fire", true);
        //    anim.SetBool("Idle", false);
        //    anim.SetBool("Move", false);
        //    currentTime = 0;
        //}

        //if (fire == true)
        //{
        //    gun.SetActive(true);
        //Camera.main.transform.position = shoot.transform.position;
        //Camera.main.transform.rotation = shoot.transform.rotation;
        //    currentTime += Time.deltaTime;
        //    if (currentTime >= fireTime)
        //    {
        //        anim.SetBool("Fire", false);
        //        currentTime = 0;
        //        fire = false;
        //    }

        //}
        //else
        //{       
        //        gun.SetActive(false);
        //Camera.main.transform.position = normal.transform.position;
        //Camera.main.transform.rotation = normal.transform.rotation;
        //}
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        if (state == State.Swim)
        {
            UpdateSwim();
        }
        if (state == State.Shoot)
        {
            UpdateShoot();
        }

        Vector3 dir = new Vector3(x, 0, z);
        Vector3 cdir = Camera.main.transform.TransformDirection(dir).normalized;

        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(cdir * speed);

    }
    void UpdateIdle()
    {
        Camera.main.transform.position = normal.transform.position;
        Camera.main.transform.rotation = normal.transform.rotation;
        currentTime = 0;
        gun.SetActive(false);
        anim.SetBool("Idle", true);
        anim.SetBool("Move", false);
        anim.SetBool("Fire", false);
        if (playerInput.IsShootingButton)
        {
            state = State.Shoot;
        }
        if (z > 0)
        {
            state = State.Swim;
        }
    }

    void UpdateSwim()
    {
        currentTime = 0;
        Camera.main.transform.position = swim.transform.position;
        Camera.main.transform.rotation = swim.transform.rotation;
        gun.SetActive(false);
        anim.SetBool("Fire", false);
        anim.SetBool("Move", true);
        anim.SetBool("Idle", false);
        if (playerInput.IsShootingButton)
        {
            state = State.Shoot;
        }
        if (z <= 0)
        {
            state = State.Idle;
        }
    }

    void UpdateShoot()
    {
        Camera.main.transform.position = shoot.transform.position;
        Camera.main.transform.rotation = shoot.transform.rotation;
        anim.SetBool("Fire", true);
        anim.SetBool("Move", false);
        anim.SetBool("Idle", false);
        currentTime += Time.deltaTime;
        gun.SetActive(true);
        if (currentTime >= fireTime && z == 0)
        {
            state = State.Idle;
        }
        if (currentTime >= fireTime && z > 0)
        {
            state = State.Swim;
        }


    }

}
