using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput playerInput;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = playerInput.XAxisDir;
        float z = playerInput.ZAxisDir;

        Vector3 dir = Vector3.right * x + Vector3.forward * z;
        transform.position += dir * speed * Time.deltaTime;
        dir.Normalize();
        
        // 마우스 포인트 위치로
        // 플레이어가 바라본다.



    }
}
