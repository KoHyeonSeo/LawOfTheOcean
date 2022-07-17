using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Vector3 initialRotation;
    
    [SerializeField] private float speed = 2;
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
    }

    
    
    // Update is called once per frame
    void Update()
    {
        // 플레이어가 입력받는 방향으로 움직일때
        // 물의 저항값이 증가한다.
        float x = playerInput.XAxisDir;
        float z = playerInput.ZAxisDir;
        
        Vector3 dir = new Vector3(x, 0, z);
        Vector3 cdir = Camera.main.transform.TransformDirection(dir).normalized;
        GetComponent<Rigidbody>().AddForce(cdir * speed);
        //if ( x < 0)
        //{
        //    GetComponent<Rigidbody>().AddForce(moveForward + moveRight);
        //}
        ////if (x == 0 && speed >= 0)
        ////{
        ////    speed -= Time.deltaTime;
            
        ////}
        //print(speed);
        //if ( x > 0)
        //{
        //    GetComponent<Rigidbody>().AddForce(moveForward);
        //}
        //if ( z < 0)
        //{
        //    GetComponent<Rigidbody>().AddForce(-moveRight);
        //}
        //if (z > 0)
        //{
        //    GetComponent<Rigidbody>().AddRelativeForce(moveRight);
        //}
        // 만약 입력이 되면 ( x값이 0보다 커진다면) speed값을 증가시킨다.
        // speed 값이 증가되면서 속도가 빨라진다.
        // speed 가 -면 왼쪽 +면 오른쪽
        // 문제 x가 0이면 멈춘다.
        // if (x == -1)
        // {
        //     adSpeed -= Time.deltaTime;
        // }
        //if ( x == 0)
        // {
        //     adSpeed = Mathf.Lerp(adSpeed, 0, Time.deltaTime);
        // }
        // if (x == 1)
        // {
        //     adSpeed += Time.deltaTime;
        // }
        // if (x != 0)
        // {
        // }


       // dir = Vector3.right * x + Vector3.forward * z;
       //    dir.Normalize();
       //    dir = Camera.main.transform.TransformDirection(dir);
       //transform.position += dir * speed * Time.deltaTime;
    }

}
