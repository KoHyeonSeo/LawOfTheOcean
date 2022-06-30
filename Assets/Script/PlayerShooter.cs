using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 입력값, 총알
public class PlayerShooter : MonoBehaviour
{
    [Header("총알 관련 설정")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMaxDistance = 1100;

    private RaycastHit hit;
    private PlayerInput playerInput;
    public Vector3 EnemyPosition { get; private set; }
    public Vector3 BulletMaxDirection { get; private set; }
    public bool IsEnemyHit { get; set; }
    private void Start()
    {
        IsEnemyHit = false;
        //playerInput이 필요하다.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        Vector3 dir = new Vector3(this.transform.position.x + playerInput.MousePosition.x, playerInput.MousePosition.y, this.transform.position.z + bulletMaxDistance);
        Debug.DrawRay(transform.position, dir.normalized * bulletMaxDistance, Color.red);
        //어딘가에 닿았다면(deadzone 제외)
        if (Physics.Raycast(transform.position, dir.normalized, out hit, bulletMaxDistance) && hit.collider.tag != "DeadZone")
        {
            //마우스 왼클릭이 입력된다면
            if (playerInput.IsShootingButton)
            {
                //Debug.Log("playerInput.MousePosition = " + playerInput.MousePosition);
                //Enemy 위치로 발사한다.
                if (hit.collider.tag == "Enemy")
                {
                    IsEnemyHit = true;
                    //Debug.Log("Enemy 맞음");
                    EnemyPosition = hit.transform.position;
                    Instantiate(bullet);
                }
            }
        }
        //deadzone또는 어느곳에도 닿지 않았을 경우
        else
        {
            //마우스 왼클릭이 입력된다면
            if (playerInput.IsShootingButton)
            {
                BulletMaxDirection = dir;
                //총알을 생성한다.
                bullet.transform.position = this.transform.position;
                Instantiate(bullet);
            }
        }  
    }
}
