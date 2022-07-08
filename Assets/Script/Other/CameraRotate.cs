using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private PlayerInput playerInput;
    float rx;
    float ry;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1.마우스의 입력값을 이용해서
        float mx = playerInput.XMouseOut;
        float my = playerInput.YMouseOut;
        rx += my;
        ry += mx;

        rx = Mathf.Clamp(rx, -80, 80);
        // 2.회전하고싶다.
        transform.eulerAngles = new Vector3(-rx, ry, 0);
        

    }
}
