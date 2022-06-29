using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 입력값, 총알
public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    
    [System.NonSerialized]
    private PlayerInput playerInput;
    
    private void Start()
    {
        //playerInput이 필요하다.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        //마우스 왼클릭이 입력된다면
        if (playerInput.IsShootingButton)
        {
            Debug.Log("마우스 포인터: " + playerInput.MousePosition);
            //총알을 생성한다.
            bullet.transform.position = this.transform.position;
            Instantiate(bullet);
        }  
    }
}
